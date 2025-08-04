-- create database ECommerceDB
-- use ECommerceDB

create table order_1nf(
	OrderID int,
	CustomerID int,
	CustomerName Varchar(100),
	CustomerPhone bigint,
	ProductID int,
	ProductPrice decimal(10,2),
	CategoryName varchar(100)
);

insert into order_1nf values
(1001,1011,'Abhay','1234567890',101,'1500.00','laptop'),
(1002,1012,'Rana','1234347890',102,'2500.00','Phone'),
(1003,1013,'Rohan','1234563490',103,'4500.00','ipad'),
(1004,1014,'Rahul','1904567890',104,'1000.00','Books'),
(1005,1015,'Sashi','1234556890',105,'1560.00','Magazines');

drop table order_1nf;

select * from order_1nf;


-----------------------------2nf--------------------------------


CREATE TABLE Orders_2nf (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT
);

CREATE TABLE Customers_2nf (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerPhone BIGINT
);

CREATE TABLE Products_2nf (
    ProductID INT PRIMARY KEY,
    ProductPrice DECIMAL(10,2),
    CategoryName VARCHAR(100)
);

-- Insert into Customers
INSERT INTO Customers_2nf VALUES
(1011, 'Abhay', 1234567890),
(1012, 'Rana', 1234347890),
(1013, 'Rohan', 1234563490),
(1014, 'Rahul', 1904567890),
(1015, 'Sashi', 1234556890);

-- Insert into Products
INSERT INTO Products_2nf VALUES
(101, 1500.00, 'laptop'),
(102, 2500.00, 'Phone'),
(103, 4500.00, 'ipad'),
(104, 1000.00, 'Books'),
(105, 1560.00, 'Magazines');

-- Insert into Orders
INSERT INTO Orders_2nf VALUES
(1001, 1011, 101),
(1002, 1012, 102),
(1003, 1013, 103),
(1004, 1014, 104),
(1005, 1015, 105);

SELECT * FROM Orders_2nf;
SELECT * FROM Customers_2nf;
SELECT * FROM Products_2nf;


------------------------------ 3nf------------------------------

CREATE TABLE Orders_3nf (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ProductID INT
);

CREATE TABLE Customers_3nf (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerPhone BIGINT
);

CREATE TABLE Products_3nf (
    ProductID INT PRIMARY KEY,
    CategoryID INT,
    ProductPrice DECIMAL(10,2)
);

CREATE TABLE Categories_3nf (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);

INSERT INTO Categories_3nf VALUES
(1, 'laptop'),
(2, 'Phone'),
(3, 'ipad'),
(4, 'Books'),
(5, 'Magazines');

-- Insert into Products
INSERT INTO Products_3nf VALUES
(101, 1, 1500.00),
(102, 2, 2500.00),
(103, 3, 4500.00),
(104, 4, 1000.00),
(105, 5, 1560.00);

-- Insert into Customers
INSERT INTO Customers_3nf VALUES
(1011, 'Abhay', 1234567890),
(1012, 'Rana', 1234347890),
(1013, 'Rohan', 1234563490),
(1014, 'Rahul', 1904567890),
(1015, 'Sashi', 1234556890);

-- Insert into Orders
INSERT INTO Orders_3nf VALUES
(1001, 1011, 101),
(1002, 1012, 102),
(1003, 1013, 103),
(1004, 1014, 104),
(1005, 1015, 105);

select * from Orders_3nf;
select * from Categories_3nf;
select * from Products_3nf;
select * from Customers_3nf;