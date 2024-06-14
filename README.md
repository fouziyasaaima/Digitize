Digitize - A sample Blazor CRUD Application

Welcome to Digitize, a sample Blazor CRUD (Create, Read, Update, Delete) application that demonstrates basic operations on Aadhaar details using Dapper and Microsoft.Data.SqlClient. This README will guide you through setting up and running the application.


Introduction
Digitize is a simple Blazor WebAssembly application that illustrates CRUD operations using a SQL Server database. This sample project leverages Dapper, a lightweight ORM, for efficient data access, and Microsoft.Data.SqlClient for database connectivity.

Features
Create new Aadhaar records.
Read and display a list of Aadhaar records.
Update existing Aadhaar records.
Delete Aadhaar records.
Utilizes Dapper for database interactions.
Uses Microsoft.Data.SqlClient for database connectivity.

Prerequisites
Before running the application, ensure you have the following tools installed:
.NET 6 SDK
SQL Server (or SQL Server Express)
Visual Studio 2022 or Visual Studio Code

Getting Started
Clone the Repository
First, clone the repository to your local machine using Git:


git clone https://github.com/fouziyasaaima/Digitize.git

cd Digitize

Setup the Database
Create a Database: Create a SQL Server database named DigitizeDb.

Run the Script: Use the following SQL script to create the Aadhaar table:


CREATE TABLE Aadhaar (
    IdAdhar INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    DOB DATE,
    FatherName NVARCHAR(100),
    Address NVARCHAR(200),
    Phone NVARCHAR(15),
    UidNo BIGINT
);

Configuration
Connection String: Update the connection string in the appsettings.json file located in the Digitize.Server project:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server_name;Database=DigitizeDb;User Id=your_username;Password=your_password;"
  }
}
Replace your_server_name, your_username, and your_password with your SQL Server details.


Run the Application
Open the solution in Visual Studio or your preferred IDE.
Build the solution to restore the dependencies and ensure everything is set up correctly.
Run the application (F5 in Visual Studio or dotnet run in the terminal).
The application will be accessible at https://localhost:5001 (or http://localhost:5000).

Project Structure
The solution Digitize consists of the following projects:

Digitize.Server: This project hosts the backend APIs for CRUD operations.
Digitize.Client: This project contains the Blazor WebAssembly application.
Digitize.Shared: This project contains shared models and utilities used by both the server and client projects.

Key Files
Digitize.Shared/Data/Aadhaar.cs: Defines the Aadhaar class model.
Digitize.Server/Controllers/MyDigitizeController.cs: Contains API endpoints for CRUD operations.
Digitize.Client/Pages/AadhaarDisplay.razor: Blazor component for managing Aadhaar records.

Usage
Adding Records: Use the "Add Aadhaar" form to create new Aadhaar records.
Viewing Records: The main page displays a list of all Aadhaar records.
Editing Records: Click the "Edit" button next to a record to update its details.
Deleting Records: Click the "Delete" button to remove a record from the database.


Fork the repository.
Create a feature branch (git checkout -b feature/your-feature).
Commit your changes (git commit -m 'Add some feature').
Push to the branch (git push origin feature/your-feature).
Open a pull request.
Please ensure your code adheres to the project's coding standards.



Contact
For any questions or inquiries, please contact:

Bandi Fouziya - saftdatasolutions@gmail.com
GitHub: fouziyasaaima

Thank you for using Digitize! We hope this project helps you manage Aadhaar details efficiently using Blazor and Dapper.
