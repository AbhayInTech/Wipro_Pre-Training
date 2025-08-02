use CollegeDb;

Select * FROM Students, Courses, StudentCourses;

-- AdventureWorks is a database provided by microsoft

-- Indexing on above table for faster lookups

CREATE NONCLUSTERED INDEX IX_STUDENT_EMAIL on Students(Email);-- Student Email

Create Nonclustered Index IX_StudentMajor_Year on Students(Major,Enrollment_year);

-- Creating a unique Index on email to prevent duplicates
Create unique index UQ_Students_Email on Students(Email) WHERE email is not null;

-- Ceate a non clustered Index on StudentCourses for common query patterns
Create Nonclustered Index IX_StudentCourses_Grade On StudentCourses(semester,grade);


-- Analysing index usage
-- Checking existing Indexes in my system

Select
	t.Name as TableName,
	i.Name as IndexName,
	i.type_desc as indexType,
	i.is_unique as IsUnique
from sys.indexes i
INNER JOIN sys.tables t ON i.object_id= t.object_id
where i.name IS NOT NULL;

Select * from students where email='John@example.com';