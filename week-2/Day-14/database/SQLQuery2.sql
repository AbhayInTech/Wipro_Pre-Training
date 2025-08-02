Use CollegeDB;

CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(50),
    email VARCHAR(50),
    major VARCHAR(50),
    enrollment_year INT
);

-- Create Courses table
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(50),
    credit_hours INT,
    department VARCHAR(50)
);

-- Create StudentCourses table for enrollment
CREATE TABLE StudentCourses (
    enrollment_id INT PRIMARY KEY,
    student_id INT,
    course_id INT,
    semester VARCHAR(20),
    grade CHAR(2),
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

-- Insert sample data
INSERT INTO Students VALUES 
(1, 'John Doe', 'john@example.com', 'Computer Science', 2020),
(2, 'Jane Smith', 'jane@example.com', 'Mathematics', 2021),
(3, 'Mike Johnson', 'mike@example.com', 'Physics', 2020);

INSERT INTO Courses VALUES
(101, 'Database Systems', 3, 'CS'),
(102, 'Calculus II', 4, 'MATH'),
(103, 'Quantum Physics', 4, 'PHYSICS');

INSERT INTO StudentCourses VALUES
(1, 1, 101, 'Fall 2023', 'A'),
(2, 1, 102, 'Spring 2024', 'B'),
(3, 2, 102, 'Fall 2023', 'A'),
(4, 3, 103, 'Spring 2024', 'B+');

Select * FRom Students, Courses,StudentCourses;

--Simple View

CREATE VIEW CS_Students AS
SELECT student_id,student_name,email
FROM Students
WHERE major='Computer Science';

Select * from CS_Students; 

--Complex View from Multiple table with joins

Create View dbo.StudentEnrollments AS
SELECT s.student_name,c.course_name,sc.semester,sc.grade
From dbo.Students s
Inner join dbo.StudentCourses sc on s.student_id=sc.student_id
Inner join dbo.Courses c on sc.course_id=c.course_id;


select * from dbo.StudentEnrollments;

UPDATE StudentCourses
SET grade = 'A'
WHERE student_id = 3 AND course_id = 103;

select * from CS_Students;

SELECT * FROM dbo.StudentEnrollments;

-- Join and Inner join there are exactly same , So inner is used for clarity
-- Query and modify View
Select Top 100 * from dbo.CS_Students;
Select top 3 * from dbo.StudentEnrollments;


Select * from dbo.StudentEnrollments where grade ='A';

-- Updating data through a view
BEGIN Transaction;
Update dbo.CS_Students
SET email = 'John_doe_university.edu'
where student_id =1;

-- verifying the update operation 
SELECT *from dbo.CS_Student where student_id=1;
Rollback transaction --undoing the change


-- Attempting to update a complex view usinf=g error handling (will fail)
Begin Try
    begin transaction
        Update dbo.StudentEnrollments
        set Grade ='A+'
        Where student_name ='John Doe' And course_name='Database Systems';
    commit Transaction;
End try
Begin catch
    Rollback transaction;
    print 'Error Occured ' +ERROR_MESSAGE();
end catch;

select * from students ;
select * from StudentCourses;

-- Altering a view ( MSSQL uses CREATE or ALTER in newer version)
-- for older version, we need to Drop and create

IF EXISTS(select * from sys.views WHERE name='CS_Students' AND schema_ID= SCHEMA_ID('dbo'))
DROP view dbo.CS_Students;

create view dbo.CS_Students_New As
select student_id, student_name, email,enrollment_year
From dbo.Students
Where major= 'Computer Science';

Select * from dbo.CS_Students_New;

-- view Metadata in MS SQL
-- GEt view defination
Select OBJECT_DEFINITION(OBJECT_ID('dbo.CS_Student_Name')) AS ViewDefinition;

-- List all the view in the database
select name as ViewName, create_date, modify_date
from sys.views
where is_ms_shipped =0
order by name;