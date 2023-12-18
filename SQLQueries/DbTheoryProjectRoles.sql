/*-- Create Admin role
CREATE ROLE Admin;

-- Create Product Manager role
CREATE ROLE ProductManager;

-- Create Sales Manager role
CREATE ROLE SalesManager;

-- Create Customer Support role
CREATE ROLE CustomerSupport;

-- Create Finance Manager role
CREATE ROLE FinanceManager;

-- Admin Role Permissions (Full access to all tables)
GRANT SELECT, INSERT, UPDATE, DELETE ON ProductCategories TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Products TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Customers TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Orders TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON OrderDetails TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Reviews TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Invoices TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Cart TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON CartDetails TO Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON Shipment TO Admin;

-- Product Manager Role Permissions
GRANT SELECT, INSERT, UPDATE, DELETE ON ProductCategories TO ProductManager;
GRANT SELECT, INSERT, UPDATE, DELETE ON Products TO ProductManager;

-- Sales Manager Role Permissions
GRANT SELECT ON Orders TO SalesManager;
GRANT SELECT, INSERT, UPDATE ON OrderDetails TO SalesManager;
GRANT SELECT ON Customers TO SalesManager;
GRANT SELECT ON Invoices TO SalesManager;

-- Customer Support Role Permissions
GRANT SELECT, UPDATE ON Customers TO CustomerSupport;
GRANT SELECT ON Orders TO CustomerSupport;
GRANT SELECT ON OrderDetails TO CustomerSupport;
GRANT SELECT ON Reviews TO CustomerSupport;
GRANT SELECT ON Shipment TO CustomerSupport;

-- Finance Manager Role Permissions
GRANT SELECT, UPDATE ON Invoices TO FinanceManager;
GRANT SELECT ON Orders TO FinanceManager;
GRANT SELECT ON Customers TO FinanceManager;
GRANT SELECT ON OrderDetails TO FinanceManager;

-- Create and assign users to roles
CREATE LOGIN AdminUser WITH PASSWORD = 'Admin123';
CREATE USER AdminUser FOR LOGIN AdminUser;
ALTER ROLE Admin ADD MEMBER AdminUser;

CREATE LOGIN ProductManagerUser WITH PASSWORD = 'ProductManager123';
CREATE USER ProductManagerUser FOR LOGIN ProductManagerUser;
ALTER ROLE ProductManager ADD MEMBER ProductManagerUser;

CREATE LOGIN SalesManagerUser WITH PASSWORD = 'SalesManager123';
CREATE USER SalesManagerUser FOR LOGIN SalesManagerUser;
ALTER ROLE SalesManager ADD MEMBER SalesManagerUser;

CREATE LOGIN CustomerSupportUser WITH PASSWORD = 'CustomerSupport123';
CREATE USER CustomerSupportUser FOR LOGIN CustomerSupportUser;
ALTER ROLE CustomerSupport ADD MEMBER CustomerSupportUser;

CREATE LOGIN FinanceManagerUser WITH PASSWORD = 'FinanceManager123';
CREATE USER FinanceManagerUser FOR LOGIN FinanceManagerUser;
ALTER ROLE FinanceManager ADD MEMBER FinanceManagerUser;

-- Deny specific permissions to the Product Manager role
-- (Assuming you want to deny DELETE permissions on ProductCategories and Products)
-- Deny specific permissions to the Sales Manager role
-- (Assuming you want to deny INSERT and UPDATE permissions on Orders and OrderDetails)
DENY INSERT, UPDATE ON Orders TO SalesManager;
DENY INSERT, UPDATE ON OrderDetails TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON ProductCategories TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Products TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Customers TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Reviews TO SalesManager;
DENY INSERT, UPDATE, DELETE ON Invoices TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Cart TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON CartDetails TO SalesManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Shipment TO SalesManager;
-- Deny specific permissions to the Product Manager role
-- (Assuming you want to deny DELETE permissions on ProductCategories and Products)
DENY DELETE ON ProductCategories TO ProductManager;
DENY DELETE ON Products TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Customers TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Orders TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON OrderDetails TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Reviews TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Invoices TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Cart TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON CartDetails TO ProductManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Shipment TO ProductManager;
-- Deny specific permissions to the Customer Support role
-- (Assuming you want to deny UPDATE permissions on Customers and Orders)
DENY UPDATE ON Customers TO CustomerSupport;
DENY UPDATE ON Orders TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON ProductCategories TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON Products TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON Reviews TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON Invoices TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON Cart TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON CartDetails TO CustomerSupport;
DENY SELECT, INSERT, UPDATE, DELETE ON Shipment TO CustomerSupport;
-- Deny specific permissions to the Finance Manager role
-- (Assuming you want to deny UPDATE permissions on Invoices and Orders)
DENY UPDATE ON Invoices TO FinanceManager;
DENY UPDATE ON Orders TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON ProductCategories TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Products TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Customers TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON OrderDetails TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Reviews TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Cart TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON CartDetails TO FinanceManager;
DENY SELECT, INSERT, UPDATE, DELETE ON Shipment TO FinanceManager;*/
--GRANT INSERT, UPDATE ON Customers TO CustomerSupport;
--grant select on Invoices to SalesManager;