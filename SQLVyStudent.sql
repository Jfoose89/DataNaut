CREATE VIEW dbo.StudentOverview
AS
SELECT
    s.StudentID,
    s.FirstName + ' ' + s.LastName AS StudentName,
    s.Email,
    COALESCE(s.StudentStatus, 'Enrolled') AS StudentStatus,
CASE
    WHEN s.StartDate = '0001-01-01' THEN '2025-01-01'
    ELSE s.StartDate
END AS StartDate,
    COUNT(e.FKCourseID) AS CourseCount
FROM dbo.Students s
LEFT JOIN dbo.Enrollments e
    ON s.StudentID = e.FKStudentID
GROUP BY
    s.StudentID,
    s.FirstName,
    s.LastName,
    s.Email,
    s.StudentStatus,
    s.StartDate,
    s.EndDate;
