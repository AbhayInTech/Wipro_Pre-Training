-- create database OfficeDB
-- use OfficeDB;

CREATE TABLE Employee_1NF (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Role VARCHAR(50),
    Dept VARCHAR(50),
    DeptLocation VARCHAR(50),
    ManagerName VARCHAR(100),
    ManagerRole VARCHAR(50),
    ManagerDept VARCHAR(50)
);

INSERT INTO Employee_1NF (EmpID, EmpName, Role, Dept, DeptLocation, ManagerName, ManagerRole, ManagerDept)
VALUES
(201, 'Alice Brown', 'HR Executive', 'HR', 'Mumbai', 'Priya Mehta', 'HR Manager', 'HR'),
(202, 'Bob Smith', 'IT Analyst', 'IT', 'Pune', 'Karan Kapoor', 'IT Head', 'IT'),
(203, 'John Davis', 'HR Executive', 'HR', 'Mumbai', 'Priya Mehta', 'HR Manager', 'HR'),
(204, 'Riya Shah', 'HR Manager', 'HR', 'Mumbai', 'Arjun Sharma', 'HR Director', 'HR'),
(205, 'Priya Mehta', 'HR Manager', 'HR', 'Mumbai', 'Arjun Sharma', 'HR Director', 'HR');


select * from Employee_1NF;


--------------------------------2nf-------------------------------

CREATE TABLE Employee_2nf (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Role VARCHAR(50),
);

INSERT INTO Employee_2nf (EmpID, EmpName, Role)
VALUES
(201, 'Alice Brown', 'HR Executive'),
(202, 'Bob Smith', 'IT Analyst'),
(203, 'John Davis', 'HR Executive'),
(204, 'Riya Shah', 'HR Manager'),
(205, 'Priya Mehta', 'HR Manager');

CREATE TABLE Department_2nf (
    Dept VARCHAR(50) PRIMARY KEY,
    DeptLocation VARCHAR(50)
);

INSERT INTO Department_2nf (Dept, DeptLocation)
VALUES
('HR', 'Mumbai'),
('IT', 'Pune');


CREATE TABLE Manager_2nf (
    ManagerName VARCHAR(100) PRIMARY KEY,
    ManagerRole VARCHAR(50),
    ManagerDept VARCHAR(50)
);

INSERT INTO Manager_2nf (ManagerName, ManagerRole, ManagerDept)
VALUES
('Priya Mehta', 'HR Manager', 'HR'),
('Karan Kapoor', 'IT Head', 'IT'),
('Arjun Sharma', 'HR Director', 'HR');


select * from Employee_1NF;
select * from Manager_2nf;
select * from Department_2nf;
select * from Employee_2nf;

Alter table Employee_2nf drop column Dept;


----------------------------- 3nf ---------------------------------


CREATE TABLE Department_3nf (
    DeptID int PRIMARY KEY,
    Dept Varchar(50),
    DeptLocation VARCHAR(50)
);

INSERT INTO Department_3nf(DeptID,Dept, DeptLocation)
VALUES
(1,'HR', 'Mumbai'),
(2,'IT', 'Pune');


CREATE TABLE Manager_3nf (
    ManagerID INT PRIMARY KEY,
    ManagerName VARCHAR(100),
    ManagerRole VARCHAR(50),
    DeptID int,
    FOREIGN KEY (DeptID) REFERENCES Department_3nf(DeptID)
);

INSERT INTO Manager_3nf VALUES
(10001,'Priya Mehta', 'HR Manager', 1),
(10002,'Karan Kapoor', 'IT Head', 2),
(10003,'Arjun Sharma', 'HR Director', 1);



CREATE TABLE Employee_3nf (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Role VARCHAR(50),
    DeptID int,
    ManagerID INT,
    FOREIGN KEY (DeptID) REFERENCES Department_3nf(DeptID),
    FOREIGN KEY (ManagerID) REFERENCES Manager_3nf(ManagerID)
);


INSERT INTO Employee_3nf (EmpID, EmpName, Role, DeptID, ManagerID)
VALUES
(201, 'Alice Brown', 'HR Executive',1, 10001),
(202, 'Bob Smith', 'IT Analyst', 2, 10002),
(203, 'John Davis', 'HR Executive', 1, 10001),
(204, 'Riya Shah', 'HR Manager', 1, 10003),
(205, 'Priya Mehta', 'HR Manager', 1, 10003);

select * from Manager_2nf;
select * from Department_2nf;
select * from Employee_2nf;

select * from Manager_3nf;
select * from Department_3nf;
select * from Employee_3nf;

SELECT 
    e.EmpID, e.EmpName, e.Role,
    d.Dept, d.DeptLocation,
    m.ManagerName, m.ManagerRole
FROM Employee_3nf e
Inner Join Department_3nf d ON e.DeptID = d.DeptID
Inner Join Manager_3nf m ON e.ManagerID = m.ManagerID;
