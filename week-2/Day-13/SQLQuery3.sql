-- CREATE DATABASE IMS;

-- USE IMS;


CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT,
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(15)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);



-- insert records in all the tables
INSERT INTO Categories (CategoryName)
VALUES 
('Smartphones'),
('Laptops'),
('Accessories'),
('Tablets');

INSERT INTO Products (ProductName, CategoryID, Price, StockQuantity)
VALUES 
('iPhone 14', 1, 799.00, 50),
('Samsung Galaxy S22', 1, 699.00, 30),
('MacBook Pro', 2, 1299.00, 20),
('Dell XPS 13', 2, 999.00, 25),
('Wireless Mouse', 3, 25.00, 100),
('Laptop Bag', 3, 45.00, 80),
('iPad Air', 4, 599.00, 40);

INSERT INTO Customers (CustomerName, Email, Phone)
VALUES 
('Alice', 'alice@example.com', '9876543210'),
('Bob Smith', 'bob@example.com', '8765432109'),
('Charlie Lee', 'charlie@example.com', '7654321098');

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
VALUES 
(1, '2025-08-01', 1548.00),
(1, '2025-08-02', 1744.00),  
(2, '2025-08-03', 599.00);   

-- Order 1 (Alice): iPhone 14 + Laptop Bag
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 1, 799.00),  -- iPhone 14
(1, 6, 1, 45.00);   -- Laptop Bag


-- Order 2 (Alice): MacBook Pro + Wireless Mouse
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
VALUES 
(2, 3, 1, 1299.00), -- MacBook Pro
(2, 5, 2, 25.00);   -- 2x Wireless Mouse

-- Order 3 (Bob): iPad Air
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
VALUES 
(3, 7, 1, 599.00);  -- iPad Air



-- view all tables
select * from Products;
select * from Categories;
select * from Orders;
select * from OrderDetails;
select * from Customers;


-- View total sales per product category / Sales Report
SELECT 
    c.CategoryName,
    SUM(od.Quantity * od.UnitPrice) AS TotalSales
FROM 
    Categories c
Inner JOIN 
    Products p ON c.CategoryID = p.CategoryID
Inner JOIN 
    OrderDetails od ON p.ProductID = od.ProductID
GROUP BY 
    c.CategoryName
ORDER BY 
    TotalSales DESC;



-- Track product inventory levels.(low stock items)
SELECT 
    ProductID,
    ProductName,
    StockQuantity
FROM 
    Products
ORDER BY 
    StockQuantity ASC;



-- Fetch order details with customer information.
SELECT 
    o.OrderID,
    o.OrderDate,
    c.CustomerName,
    c.Email,
    c.Phone,
    p.ProductName,
    od.Quantity,
    od.UnitPrice
FROM 
    Orders o
Inner JOIN 
    Customers c ON o.CustomerID = c.CustomerID
Inner JOIN 
    OrderDetails od ON o.OrderID = od.OrderID
Inner JOIN 
    Products p ON od.ProductID = p.ProductID
WHERE 
    o.OrderID = 101;



-- Ensure atomicity during bulk stock update
BEGIN TRANSACTION;

BEGIN TRY
    -- Assume 2 products in a bulk order
    UPDATE Products SET StockQuantity = StockQuantity - 3 WHERE ProductID = 1;
    UPDATE Products SET StockQuantity = StockQuantity - 2 WHERE ProductID = 5;

    -- Ensure no negative stock
    IF EXISTS (SELECT 1 FROM Products WHERE StockQuantity < 0)
    BEGIN
        THROW 50001, 'Stock quantity cannot be negative.', 1;
    END

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH;




-- Stored Procedure for Order Insertion
CREATE PROCEDURE InsertOrderWithDetails
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10,2)
AS
BEGIN
    DECLARE @OrderID INT;
    DECLARE @TotalAmount DECIMAL(10,2) = @Quantity * @UnitPrice;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insert into Orders
        INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
        VALUES (@CustomerID, GETDATE(), @TotalAmount);

        SET @OrderID = SCOPE_IDENTITY();

        -- Insert into OrderDetails
        INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
        VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);

        -- Update Stock
        UPDATE Products
        SET StockQuantity = StockQuantity - @Quantity
        WHERE ProductID = @ProductID;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT ERROR_MESSAGE();
    END CATCH;
END;


DROP FUNCTION IF EXISTS GetDiscountedPrice;


--Dynamic Discount Calculation Function
CREATE FUNCTION GetDiscountedPrice
(
    @Price DECIMAL(10,2),
    @Discount decimal(5,2),
    @Quantity INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Price * (1 - @Discount/100);
END;


SELECT 
    ProductID,
    Quantity,
    UnitPrice,
    dbo.GetDiscountedPrice(UnitPrice,10, Quantity) AS DiscountedPrice
FROM 
    OrderDetails;

-- Customer Order history (multi table join)
SELECT 
    c.CustomerName,
    o.OrderID,
    o.OrderDate,
    p.ProductName,
    od.Quantity,
    od.UnitPrice,
    (od.Quantity * od.UnitPrice) AS SubTotal
FROM 
    Customers c
INNER JOIN 
    Orders o ON c.CustomerID = o.CustomerID
INNER JOIN 
    OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN 
    Products p ON od.ProductID = p.ProductID
ORDER BY 
    c.CustomerName, o.OrderDate;

create function GetProductByCategory(@CategoryID int)
returns table
AS
return 
(Select productName, price, productId, StockQuantity
from products where
categoryID=@categoryID);

select * from dbo.GetProductByCategory(1);




CREATE PROCEDURE PlaceOrderTransaction
    @CustomerID INT,
    @ProductID INT,
    @Qty INT
AS
BEGIN
    DECLARE @TotalAmount DECIMAL(10,2);
    DECLARE @UnitPrice DECIMAL(10,2);
    DECLARE @OrderID INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Step 1: Check stock
        IF (SELECT StockQuantity FROM Products WHERE ProductID = @ProductID) < @Qty
        BEGIN
            PRINT 'Insufficient stock for this product.';
            ROLLBACK;
            RETURN;
        END
        PRINT 'Sufficient Stock';

        -- Step 2: Deduct stock
        UPDATE Products
        SET StockQuantity = StockQuantity - @Qty
        WHERE ProductID = @ProductID;
        PRINT 'Product is deducted from the stock';

        -- Get unit price and calculate total
        SELECT @UnitPrice = Price FROM Products WHERE ProductID = @ProductID;
        SET @TotalAmount = @Qty * @UnitPrice;
        PRINT 'Total Price is Calculated';

        -- Step 3: Create order and get OrderID
        INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
        VALUES (@CustomerID, GETDATE(), @TotalAmount);
        Print 'Order is created'; 

        SET @OrderID = SCOPE_IDENTITY();  -- Get the generated OrderID

        -- Step 4: Insert into order details
        INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
        VALUES (@OrderID, @ProductID, @Qty, @UnitPrice);
        PRINT 'Order';

        -- Step 5: commiting the Transaction
        COMMIT;
        PRINT 'Order placed successfully.';
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Order failed: ';
    END CATCH
END;

EXEC PlaceOrderTransaction @CustomerID = 1, @ProductID = 1, @Qty = 42;

DROP Procedure IF EXISTS PlaceOrderTransaction;

-- view all tables
select * from Products;
select * from Categories;
select * from Orders;
select * from OrderDetails;
select * from Customers;
