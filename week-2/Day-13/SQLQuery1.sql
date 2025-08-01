-- DQL (Data Query Language)  => SELECT
select * from student;
-- DDL (Data Definition Language) => CREATE, ALTER, DROP, TRUNCATE
CREATE table Student(
	SID int primary key,
	SName varchar(50),
	Course varchar(50),
	Age int
);

ALTER table student ADD gender char(1);
Alter table student Modify gender varchar(10);-- modify clolumn type
Alter table student change gender category varchar(10);
Alter table student drop column age;
Alter table student add age int;
update student set age=21 where sid =123 or sid =456;

RENAME TABLE student to college_student;

Drop table Students;

Truncate Table Student;

-- DML(Data Manipulationn Language) => INSERT, UPDATE, DELETE
Insert into Student values(123,'Abhay','BCA',20,'M');
Insert into Student (SID, SName, Course, Age,gender) Values (456,'Rana','MCA',21,'M');

Update Student set age=21 where sid=123;

Delete from student where sid =456;

-- DCL (Data Control Language) => Grant and revoke

-- TCL (Transaction Control Language) => commit, Rollback, Savepoint

--Advance Query envolve => Aggregate function , joins , set function, sub query,groupby and having clause
select count(*) as NumberOfRecords from student;
alter table student add cId int;
update student set cId=101 where SID=123;
update student set cId=102 where Sid=456;
Select * from student;
create table Course (
	cID int,
	CName varchar(100),
	CFaculty Varchar(100)
);
insert into course values(101,'BCA','SK.Pandye'),(102,'BBA','SK.JHA'),(103,'BCom','SK.Sinha');
select * from course;
select s.SName , c.CName from student s Inner join course c on s.cId=c.cId;
CREATE VIEW elder_student AS
SELECT Sname, Sid FROM student WHERE age > 20;
