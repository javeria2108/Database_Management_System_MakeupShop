/*-- Create Product Categories Table
CREATE TABLE ProductCategories (
    CategoryID INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000)
);

-- Create Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    CategoryID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Description NVARCHAR(1000),
    ImageURL NVARCHAR(1000),
    StockQuantity INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES ProductCategories(CategoryID)
);

-- Create Users Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    RegistrationDate DATETIME NOT NULL,
    LastLoginDate DATETIME
);
-- Create Orders Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    FOREIGN KEY ( CustomerID) REFERENCES  Customers( CustomerID)
);

-- Create Order Details Table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


-- Create Reviews Table
CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY IDENTITY,
    ProductID INT NOT NULL,
    CustomerID INT NOT NULL,
    Rating INT NOT NULL,
    Comment NVARCHAR(MAX),
    ReviewDate DATETIME NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY ( CustomerID) REFERENCES  Customers( CustomerID)
);
CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY,
    OrderID INT,
    InvoiceDate DATE,
    TotalAmount DECIMAL(10, 2),
    PaymentDetails VARCHAR(255),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);	
CREATE TABLE Cart (
    CartID INT PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    DateCreated DATETIME NOT NULL,
    FOREIGN KEY ( CustomerID) REFERENCES Customers( CustomerID)
);
CREATE TABLE CartDetails (
    CartDetailID INT PRIMARY KEY IDENTITY,
    CartID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    DateAdded DATETIME NOT NULL,
    FOREIGN KEY (CartID) REFERENCES Cart(CartID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
CREATE TABLE Shipment (
    shipment_id INT PRIMARY KEY IDENTITY,
    orderID INT NOT NULL,
    shipment_date DATE,
    address NVARCHAR(255),
    city NVARCHAR(100),
    state NVARCHAR(100),
    country NVARCHAR(100),
    zip_code NVARCHAR(20),
    FOREIGN KEY (orderID) REFERENCES Orders(OrderID)
);
*/


/*INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES
(18, 3, 2)
INSERT INTO Invoices (InvoiceID, OrderID, InvoiceDate, TotalAmount, PaymentDetails)
VALUES (
    (SELECT MAX(InvoiceID) + 1 FROM Invoices),  -- Generating InvoiceID assuming it's not an IDENTITY column
    18,  -- Replace with the actual OrderID for which the invoice is being generated
    GETDATE(),  -- Current date as Invoice Date
    (SELECT SUM(Products.Price * OrderDetails.Quantity)
     FROM OrderDetails
     INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
     WHERE OrderDetails.OrderID = 18),  -- Subquery to calculate TotalAmount
    'Credit Card'  -- Replace with actual payment details
);
-- First, remove the existing InvoiceID column if it exists
-- Step 1: Drop the existing primary key constraint

IF OBJECT_ID('dbo.Invoices', 'U') IS NOT NULL
BEGIN
    ALTER TABLE Invoices
    DROP COLUMN InvoiceID;
END
-- Step 2: Alter the table to add InvoiceID as an identity column
ALTER TABLE Invoices
ADD InvoiceID INT IDENTITY(1, 1);

-- Step 3: Add a new primary key constraint on InvoiceID
ALTER TABLE Invoices
ADD CONSTRAINT PK_Invoices PRIMARY KEY (InvoiceID);
*/
alter table CartDetails
drop column DateAdded