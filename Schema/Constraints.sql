-- Unique Constraints query

USE DatanautDB;
GO

ALTER TABLE Role
ADD CONSTRAINT UQ_Role_RoleName UNIQUE (RoleName);

ALTER TABLE Resources
ADD CONSTRAINT UQ_Resources_Name_Project UNIQUE (ResourceName, FKProjectID);

ALTER TABLE Report
ADD CONSTRAINT UQ_Report_Project_DateRange UNIQUE (FKProjectID, ReportStartDate, ReportEndDate);
