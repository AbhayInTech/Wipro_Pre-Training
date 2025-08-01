-- Create Database CollegeDB;

-- use collegeDb;

/*
create table student(
	studentID int primary key,
	FullName varchar(100) not null,
	Email varchar(100) unique not null,
	Age int check(age>=18)
);
*/

/*
create table instructor(
	InstructorID int Primary key,
	FullName Varchar (100),
	Email varchar(100) unique
);
*/

/*
create table course(
	courseID int primary key,
	FullName varchar(100),
	Email varchar(100) unique
);
*/

/*
ALTER TABLE course DROP CONSTRAINT UQ__course__A9D1053424B32B20;
alter table course drop column Email;
alter table course drop column FullName;
Alter table course add CourseName varchar(100);
Alter table course add InstructorID int 
Foreign Key (InstructorID) References Instructor(InstructorID)
;
Select * from course;
*/

/*
create table Enrollment(
	EnrollmentID int primary key,
	StudentID int,
	CourseID int,
	EnrollmentDate date Default Getdate(),
	Foreign key (StudentID) References Student(StudentID),
	Foreign key (CourseID) References Course(CourseID),
);
*/

/*
Insert into Instructor values
(1,'Dr. Smith','Smith@gmail.com'),
(2,'Dr. Abhay','Abhay@gmail.com'),
(3,'Dr. Rana','Rana@gmail.com')
;
*/

-- insert into course table
/*
insert into course Values
(101,'Data Science',1),
(102,'.NET FSD Azure Cloud',2);

-- insert into student table
Insert into Student values (1,'Rohit','Rohit@UCLA.UK',17); --- will not work as age is less than 18
Insert into Student values (1,'Rohit','Rohit@UCLA.UK',19);
Insert into Student values (1,'Rohit','Rohit@UCLA.UK',19);-- will not accepted as email is not unique
Insert into Student values (2,'Rana','Rana@UCLA.UK',19);

-- inserting value with Enrollment 
INSERT INTO Enrollment (EnrollmentID, StudentID, CourseID)
VALUES (1001, 1, 101);  -- This one is correct

INSERT INTO Enrollment VALUES (1002, 2, 103); -- Column name or number of supplied values does not match table definition.

select * from Enrollment;
select* from student;

Grant Select on student to auditor;
Grant select on Enrollment to auditor;

-- for above to work we have to create login and users
Create Login auditor with Password='StrongPassword123';
Create user auditor for login auditor;

revoke select on student from auditor;
-- Delete from student where StudentId = 3;

-- Implementing a transaction with commit and rollback
Begin Transaction;
Insert into Student Values (3,'Alex','Alex@HWD.edu',20);
insert into Enrollment values(1003,3,101,GETDATE());
Commit;

-- Implement RollBack
Begin Transaction;
insert into Student Values(4,'Angel','Angel@Ucla.com',17);
Rollback;
*/

-- structure of my tables
select * from course;
select * from Enrollment;
select * from instructor;
select * from student;

-- Which student are enrolled in which course
SELECT 
    s.StudentID,
    s.FullName AS StudentName,
    c.CourseID,
    c.CourseName
FROM 
    Enrollment e
Inner JOIN 
    Student s ON e.StudentID = s.StudentID
Inner JOIN 
    Course c ON e.CourseID = c.CourseID;

-- who is teaching each course
SELECT 
    c.CourseID,
    c.CourseName,
    i.FullName AS InstructorName,
    i.Email AS InstructorEmail
FROM 
    Course c
Inner JOIN 
    Instructor i ON c.InstructorID = i.InstructorID;


/*
-- Add age check
ALTER TABLE Student
ADD CONSTRAINT chk_min_age CHECK (Age >= 18);

-- Add unique email (if not already set)
ALTER TABLE Student
ADD CONSTRAINT uq_student_email UNIQUE (Email);
*/


-- Grant SELECT only
GRANT SELECT ON Student TO auditor;
GRANT SELECT ON Course TO auditor;
GRANT SELECT ON Enrollment TO auditor;

-- Prevent UPDATE, DELETE, INSERT
DENY INSERT, UPDATE, DELETE ON Student TO auditor;
DENY INSERT, UPDATE, DELETE ON Course TO auditor;
DENY INSERT, UPDATE, DELETE ON Enrollment TO auditor;


--Stored procedure : get Student Info by ID
CREATE PROCEDURE GetStudentInfoByID
    @StudentID INT
AS
BEGIN
    SELECT 
        StudentID,
        FullName,
        Email,
        Age
    FROM 
        Student
    WHERE 
        StudentID = @StudentID;
END;

EXEC GetStudentInfoByID @StudentID = 1;
EXEC GetStudentInfoByID @StudentID = 2;
EXEC GetStudentInfoByID @StudentID = 3;


