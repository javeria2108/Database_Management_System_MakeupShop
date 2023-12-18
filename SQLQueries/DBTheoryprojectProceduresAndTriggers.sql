/*CREATE PROCEDURE CalculateOrderTotal
    @OrderID INT
AS
BEGIN
    DECLARE @TotalAmount DECIMAL(10, 2)

    -- Calculate the total amount for the specified order
    SELECT @TotalAmount = SUM(Quantity * PricePerItem)
    FROM OrderDetails
    WHERE OrderID = @OrderID

    -- Update the Orders table with the calculated total amount
    UPDATE Orders
    SET TotalPrice = @TotalAmount
    WHERE OrderID = @OrderID
END;
EXEC CalculateOrderTotal @OrderID = 1; -- Replace 123 with the actual order ID
GO
CREATE PROCEDURE CalculateAndApplyDiscounts
    @OrderID INT
AS
BEGIN
    DECLARE @TotalAmount DECIMAL(10, 2)

    -- Calculate the total amount for the order
    SELECT @TotalAmount = SUM(Quantity * PricePerItem)
    FROM OrderDetails
    WHERE OrderID = @OrderID

    -- Apply discounts based on business rules (example: 10% discount for orders over $100)
    IF @TotalAmount >= 100
    BEGIN
        SET @TotalAmount = @TotalAmount * 0.90 -- 10% discount
    END

    -- Update the Orders table with the calculated total amount including discounts
    UPDATE Orders
    SET TotalPrice = @TotalAmount
    WHERE OrderID = @OrderID
END;*/
CREATE PROCEDURE CalculateTotalAmountProcedure
    @OrderID INT
AS
BEGIN
    DECLARE @TotalAmount DECIMAL(10, 2)

    -- Calculate the total amount by summing the product prices for the given OrderID
    SELECT @TotalAmount = SUM(Products.Price * OrderDetails.Quantity)
    FROM OrderDetails
    INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
    WHERE OrderDetails.OrderID = @OrderID

    -- Return the calculated total amount
    SELECT @TotalAmount AS TotalAmount
END
--Stored procedure to delete a Customer by CustomerID
CREATE PROCEDURE DeleteCustomer
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customers
    WHERE CustomerID = @CustomerID;
END;
GO
--Trigger for storing deleted values from customers table
CREATE TRIGGER AuditCustomers
ON Customers
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Check if the audit table exists, if not, create it
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CustomersAudit')
    BEGIN
        CREATE TABLE CustomersAudit (
            AuditID INT PRIMARY KEY IDENTITY,
            Action NVARCHAR(10),  -- INSERT, UPDATE, DELETE
            CustomerID INT,
            Username NVARCHAR(255),
            Email NVARCHAR(255),
            Password NVARCHAR(255),
            RegistrationDate DATETIME,
            LastLoginDate DATETIME
        );
    END;

    -- Capture INSERT operation
    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO CustomersAudit (Action, CustomerID, Username, Email, Password, RegistrationDate, LastLoginDate)
        SELECT 'INSERT', CustomerID, Username, Email, Password, RegistrationDate, LastLoginDate
        FROM inserted;
    END;

    -- Capture UPDATE operation
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO CustomersAudit (Action, CustomerID, Username, Email, Password, RegistrationDate, LastLoginDate)
        SELECT 'UPDATE', i.CustomerID, i.Username, i.Email, i.Password, i.RegistrationDate, i.LastLoginDate
        FROM inserted AS i
        INNER JOIN deleted AS d ON i.CustomerID = d.CustomerID;
    END;

    -- Capture DELETE operation
    IF NOT EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO CustomersAudit (Action, CustomerID, Username, Email, Password, RegistrationDate, LastLoginDate)
        SELECT 'DELETE', CustomerID, Username, Email, Password, RegistrationDate, LastLoginDate
        FROM deleted;
    END;
END;
