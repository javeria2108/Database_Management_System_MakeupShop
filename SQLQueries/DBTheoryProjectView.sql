CREATE VIEW SalesByCategory AS
SELECT
    pc.CategoryID,
    pc.CategoryName,
    SUM(od.Quantity * p.Price) AS TotalSales
FROM
    ProductCategories pc
INNER JOIN
    Products p ON pc.CategoryID = p.CategoryID
INNER JOIN
    OrderDetails od ON p.ProductID = od.ProductID
GROUP BY
    pc.CategoryID, pc.CategoryName;
