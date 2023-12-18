/*DECLARE @i INT = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO ProductCategories (CategoryName, Description)
    VALUES ('Category ' + CAST(@i AS NVARCHAR(10)), 'Description for Category ' + CAST(@i AS NVARCHAR(10)));

    SET @i = @i + 1;
END
GO
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Products (CategoryID, Name, Price, Description, ImageURL, StockQuantity)
    VALUES (@i, 'Product ' + CAST(@i AS NVARCHAR(10)), 100.00, 'Description for Product ' + CAST(@i AS NVARCHAR(10)), 'http://imageurl.com/product' + CAST(@i AS NVARCHAR(10)), 50);

    SET @i = @i + 1;
END
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Customers (Username, Email, Password, RegistrationDate, LastLoginDate)
    VALUES ('User' + CAST(@i AS NVARCHAR(10)), 'user' + CAST(@i AS NVARCHAR(10)) + '@example.com', 'Password' + CAST(@i AS NVARCHAR(10)), GETDATE(), GETDATE());

    SET @i = @i + 1;
END
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Orders (CustomerID, OrderDate)
    VALUES (@i, GETDATE());

    SET @i = @i + 1;
END
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
    VALUES (@i, @i, @i);

    SET @i = @i + 1;
END
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Reviews (ProductID, CustomerID, Rating, Comment, ReviewDate)
    VALUES (@i, @i, 5, 'Review Comment for Product ' + CAST(@i AS NVARCHAR(10)), GETDATE());

    SET @i = @i + 1;
END

SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Cart (CustomerID, DateCreated)
    VALUES (@i, GETDATE());

    SET @i = @i + 1;
END
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO CartDetails (CartID, ProductID, Quantity, DateAdded)
    VALUES (@i, @i, @i, GETDATE());

    SET @i = @i + 1;
END
SET @i = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Shipment (orderID, shipment_date, address, city, state, country, zip_code)
    VALUES (@i, GETDATE(), '123 Main St', 'City' + CAST(@i AS NVARCHAR(10)), 'State' + CAST(@i AS NVARCHAR(10)), 'Country' + CAST(@i AS NVARCHAR(10)), '12345');

    SET @i = @i + 1;
END*/
DECLARE @j INT = 1;
DECLARE @orderID INT;

WHILE @j <= 10
BEGIN
    SET @orderID = @j;  -- Setting OrderID starting from 1 and incrementing

    INSERT INTO Invoices (OrderID, InvoiceDate, TotalAmount, PaymentDetails)
    VALUES 
	(@orderID,
	GETDATE(),
	(SELECT SUM(Products.Price * OrderDetails.Quantity)
     FROM OrderDetails
     INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
     WHERE OrderDetails.OrderID = @OrderID),
	 'Dummy Payment Details');  -- Assuming other details are not crucial for this example

    SET @j = @j + 1;
END



