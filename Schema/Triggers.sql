-- Tabell som loggar ändringar i TimeLog
CREATE TABLE TimeLogAudit (
    PKTimeLogAuditID INT IDENTITY(1,1) PRIMARY KEY,
    TimeLogID        INT         NOT NULL,
    FKTeamMemberID   INT         NOT NULL,
    FKReportID       INT         NOT NULL,
    Activity         VARCHAR(255) NULL,
    TimeWorked       DECIMAL(5,2) NOT NULL,
    DateLogged       DATE        NOT NULL,
    ChangeType       VARCHAR(10) NOT NULL,   -- INSERT / UPDATE / DELETE
    ChangeDate       DATETIME    NOT NULL DEFAULT GETDATE()
);
GO

-- Trigger som loggar alla ändringar i TimeLog
CREATE TRIGGER trg_TimeLog_Audit
ON TimeLog
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Logga INSERT & UPDATE (nya värden)
    INSERT INTO TimeLogAudit
        (TimeLogID, FKTeamMemberID, FKReportID, Activity, TimeWorked, DateLogged, ChangeType, ChangeDate)
    SELECT
        i.PKTimeLogID,
        i.FKTeamMemberID,
        i.FKReportID,
        i.Activity,
        i.TimeWorked,
        i.DateLogged,
        CASE 
            WHEN d.PKTimeLogID IS NULL THEN 'INSERT'
            ELSE 'UPDATE'
        END,
        GETDATE()
    FROM inserted i
    LEFT JOIN deleted d ON i.PKTimeLogID = d.PKTimeLogID;

    -- Logga DELETE (gamla värden)
    INSERT INTO TimeLogAudit
        (TimeLogID, FKTeamMemberID, FKReportID, Activity, TimeWorked, DateLogged, ChangeType, ChangeDate)
    SELECT
        d.PKTimeLogID,
        d.FKTeamMemberID,
        d.FKReportID,
        d.Activity,
        d.TimeWorked,
        d.DateLogged,
        'DELETE',
        GETDATE()
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.PKTimeLogID = d.PKTimeLogID);
END;
GO

  
--Createdat/ UpdatedAt trigger
ALTER TABLE TimeLog
ADD CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL;

ALTER TABLE Project
ADD CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL;

    ALTER TABLE Report
ADD CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL;


--AffärsLogik
-- 1) Project – hindra slutdatum före startdatum
CREATE TRIGGER trg_Project_ValidateDates
ON Project
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.ProjectEndDate IS NOT NULL
          AND i.ProjectStartDate IS NOT NULL
          AND i.ProjectEndDate < i.ProjectStartDate
    )
    BEGIN
        RAISERROR ('ProjectEndDate får inte vara tidigare än ProjectStartDate.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

-- 2) TimeLog – enkel affärslogik: tid måste vara > 0
CREATE TRIGGER trg_TimeLog_Validate
ON TimeLog
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.TimeWorked <= 0
    )
    BEGIN
        RAISERROR ('TimeWorked måste vara större än 0.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

-- 3) Report – hindra slutdatum före startdatum
CREATE TRIGGER trg_Report_ValidateDates
ON Report
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.ReportEndDate IS NOT NULL
          AND i.ReportStartDate IS NOT NULL
          AND i.ReportEndDate < i.ReportStartDate
    )
    BEGIN
        RAISERROR ('ReportEndDate får inte vara tidigare än ReportStartDate.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

