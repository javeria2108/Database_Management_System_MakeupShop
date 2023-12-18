# Cosmetics Database Project

## Table of Contents
- [Introduction](#introduction)
- [Technologies](#technologies)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction
This project is a cosmetics database management system developed as part of the DBTheoryProject. It allows you to manage customers, orders, products, invoices, and more in a cosmetics retail setting. This README provides an overview of the project, its features, and how to get started.

## Technologies
- C# and .NET Framework for the desktop application.
- SQL Server for the database management system.
- WinForms for the user interface.

## Features
- Manage customer information, including registration and login.
- Create and manage orders, order details, and invoices.
- Maintain product information and categories.
- Handle cart functionality for online shopping.
- Manage shipments and reviews.
- Audit tables to keep track of changes.

## Getting Started
1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/javeria2108/Database_Management_System_MakeupShop

2.Open the project in your preferred development environment (e.g., Visual Studio).

3.Set up the database:

Make sure you have SQL Server installed.
Create a new database (e.g., "CosmeticsDatabaseProject").
Execute the SQL scripts in the database-scripts directory to create the necessary tables.
Update the connection string:

4.Open the project's code and locate the connection string in the form files (e.g., CustomersForm.cs, OrdersForm.cs, etc.).
Replace the connection string details with your own SQL Server credentials.
Build and run the project.

5.Usage
Register as a new customer or log in with existing credentials.
Use the different forms to manage customer data, orders, products, invoices, etc.
View, edit, or delete records as needed.
Use the audit functionality to keep track of changes made to tables.
##Contributing
Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Make your changes and commit them.
Push your changes to your fork.
Create a pull request to merge your changes into the main repository.
