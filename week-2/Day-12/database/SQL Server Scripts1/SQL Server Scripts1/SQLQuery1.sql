create database Office;

use office;

create TABLE Department(
DeptID int primary key,
DeptName varchar(50)
);

create Table Employee(
EmpID int primary key,
EmpName varchar(100),
Salary decimal(10,2),
DeptID int,
ManagerID int,
DateOfJoining date
);

INSERT INTO Department Values(1,'HR'),(2,'Finance'),(3,'IT');
INSERT INTO Department Values(4,'Customer Support');

INSERT INTO Employee VALUES
(101,'Raj', 70000.45,3,null,'2024-01-15'),
(102,'Rajiv', 35000,2,101,'2025-01-15'),
(103,'Rajesh', 40000.75,3,101,'2021-01-15'),
(104,'Rajni', 50000,3,102,'2022-01-15'),
(105,'Rani', 70000,1,null,'2020-01-15'),
(106,'Kishor', 80000,5,null,'2018-01-15');

INSERT INTO Employee VALUES (107,'Abhay',12345,3,null,'2025-07-31');


INSERT INTO Employee VALUES (108,'Rana',12545,3,null,'2025-07-31');

SELECT * FROM Employee;
SELECT * FROM Department;

SELECT EmpName,Len(EmpName) As NameLength FROM Employee;

SELECT EmpName, round(Salary,-3) As RoundedSalary FROM Employee;
-- positive value rounds to decimmal value (Round(123.456,2))===> 123.46
-- negative value rounds to power of 10 to the left (Round(12345,-2))===> 12300
SELECT GETDATE() As CurrentDate;

-- Aggregate Functions
SELECT count(*) As TotalEmployee FROM Employee;
SELECT round(avg(Salary),-2) As AverageSalary FROM Employee;
SELECT max(Salary) As MaxSalary FROM Employee;

-- Types of Joins
--		Inner Joins : Returns only matching rows from both the Table
SELECT E.EmpName, D.DeptName
FROM Employee E
INNER JOIN Department D ON E.DeptID = D.DeptID;

--		Left Joins : Return all rows form the left and matched rows from the right table
SELECT E.EmpName, D.DeptName
FROM Employee E
LEFT JOIN Department D ON E.DeptID = D.DeptID;

--		Right Joins :  Return all rows form the right and matched rows from the left table
SELECT E.EmpName, D.DeptName
FROM Employee E
RIGHT JOIN Department D ON E.DeptID = D.DeptID;

--		Full Joins : Returns all rows where there is match in one of the table
SELECT E.EmpName, D.DeptName
FROM Employee E
FULL OUTER JOIN Department D ON E.DeptID = D.DeptID;

--		Self Joins : A TABLE is joined to itself , after using aliases
-- Here we are returning  Employee --> Manager Mapping
SELECT E1.EmpName As Employee, E2.EmpName As Manager
FROM Employee E1
LEFT JOIN Employee E2 ON E1.ManagerID = E2.EmpID;

--		Cross Joins : Returns the cartesian Product of two TABLE
SELECT EmpName, DeptName FROM Employee cross join Department;

-- Set Operators
--		UNION
SELECT EmpName FROM Employee
UNION
SELECT DeptName FROM Department;

SELECT DeptID FROM Employee
UNION ALL
SELECT DeptID FROM Department;

--		INTERSECTION (same datatype column should be there)
SELECT DeptID FROM Employee
INTERSECT
SELECT DeptID FROM Department;

--		MINUS (not directly supported in the SQL Server use EXCEPT)
SELECT DeptID FROM Department
EXCEPT
SELECT DeptID FROM Employee;

SELECT DeptID FROM Department
MINUS
SELECT DeptID FROM Employee;

-- Lets create a stored procedure for getting employee details

CREATE PROCEDURE GetEmployeeDetails
@EmpID INT,@EmpName VARCHAR(100) OUTPUT
AS
BEGIN
SELECT @EmpName = EmpName FROM Employee WHERE EmpID = @EmpID;
END;


DECLARE @Name VARCHAR(100);

-- Execute the stored procedure
EXEC GetEmployeeDetails @EmpID = 103, @EmpName = @Name OUTPUT;

-- Print the output value
PRINT @Name;

--update employee details
create procedure UpdateEmployeeDetails
@EmpID int, @NewSalary decimal(10,2) output
AS
BEGIN
UPDATE Employee
set salary =@NewSalary
WHERE EmpID = @EmpID;
END;
execute UpdateEmployeeDetails @EmpID=103, @NewSalary= 90000;

SELECT * from Employee;

-- 
create procedure CheckSalary
@EmpID int output
AS
BEGIN
declare @salary decimal(10,2)
SELECT @salary =salary FROM Employee WHERE EmpID =@EmpID;
if @salary>55000
print 'High Salary'
else
print 'Low Salary';
END

EXECUTE CheckSalary @EmpID = 103;

-- Creating Transaction and Error  handling
BEGIN TRY
	BEGIN TRANSACTION;
	UPDATE Employee SET Salary =Salary +5000 WHERE DeptID=1;
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK;
	print 'Error_Message';
END CATCH
SELECT * FROM Employee WHERE DeptID=1;

-- Scalar Function

CREATE function GetYearOfJoining(@EmpID int)
returns int

As

BEGIN
	DECLARE @Year int;
	SELECT @Year = Year(DateOfJoining) FROM Employee Where EmpID=@EmpID;
	RETURN @Year;
END

SELECT EmpName,dbo.GetYearOfJoining(EmpID) As JoiningYear FROM Employee;


create procedure PrintEmployeeJoiningYear
@EmpID int
as
begin
declare @Year int;
set @Year = dbo.GetYearOfJoining(@EmpID); 
print 'Joined' + cast (@Year as varchar);
end
execute PrintEmployeeJoiningYear 101;