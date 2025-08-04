use CollegeDB;

Select * FROM Students,Courses,StudentCourses;
-- Indexing on above table for Faster lookups 

Create NONCLUSTERED INDEX IX_STUDENT_EMAIL on Students(email); -- student Email

--composite non clustered index on major and enrollment year 
Create NONCLUSTERED INDEX IX_StudentMajor_Year ON Students(major,enrollment_year);

-- Crating a Unique Index on email to prevent duplicates
Create UNIQUE INDEX UQ_Students_Email ON Students(email) WHERE email IS NOT NULL;

-- Create a non clustered Index on StudentCourses for common query patterns
CREATE NONCLUSTERED INDEX IX_StudentCourses_Grade ON StudentCourses(semester,grade)

-- Analysing Index usage 
--Checking existing indexes in my system
SELECT
	t.name AS TableName,
	i.name AS IndexName,
	i.type_desc AS IndexType,
	i.is_unique AS IsUnique
FROM sys.indexes i
INNER JOIN sys.tables t ON i.object_id = t.object_id
Where i.name IS NOT NULL;

--sample Queries based on indexing 
SELECT * FROM Students Where email = 'John_doe_university.edu';

--using composite index 
SELECT * FROM Students Where major ='Computer Science' AND enrollment_year  = 2020;


-- Listing  all the tables in the database 
---Constant Practice -> Knowledge -> Wisdom -> Intuation

SELECT * FROM sys.tables; 
SELECT * FROM sys.schemas;


-- Most views in MSSQL Server are read only by design? justify How ??

-- Only simple views meeting strcit criteria can be updated directly ? How ?

Select * FROM CS_Students_New; -- simple updatable view ( Meets all criteria)
SELECT * FROM StudentEnrollments; --View with Join( Not directly Updatable)
SELECT OBJECT_DEFINITION(OBJECT_ID('DBO.StudentEnrollments')) AS ViewDefinition;

-- View with DISTINCT(not updatable)
CREATE VIEW UniqueMajors AS
SELECT DISTINCT major FROM Students;
SELECT * FROM UniqueMajors;

-- Below operatioj is failing because 
-- DISTINCT create a derived result set
-- SQL SERVER can't map updates back to the base table 
BEGIN TRY 
	PRINT 'Attempting to update DISTINCT view..'
	UPDATE UniqueMajors
	SET major = 'Computer Sciences'
	Where Major = 'Computer Science'
END TRY

BEGIN CATCH
	PRINT 'update failed(as Expected)';
	PRINT 'ERROR: ' +ERROR_MESSAGE();
END CATCH;


-- View with computed column ( non updatable)
Create VIEW StudentNameLengths1 AS
SELECT student_id,student_name, LEN(student_name) AS name_length
FROM Students;
SELECT * FROM StudentNameLengths;
SELECT * FROM StudentNameLengths1;


-- Thi will fail because :
-- Contain a derived column( name_length)
-- SQL Server can't update calculated values 

BEGIN TRY
	PRINT'Attempting to updated computed column';
	UPDATE StudentNameLengths
	SET student_name = 'John Travolta'
	Where name_length = 6;
END TRY

BEGIN CATCH
	PRINT 'Update Failed( a expected)';
	PRINT 'Error' + Error_Message();
END CATCH;