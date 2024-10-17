# BADassignment-2
Assignment two of backend development

## Resources for developing ASP.NET Core Applications
RESTful web API design: https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design
Create web APIs with ASP.NET Core: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0

## Typical Errors
If you have errors, then you might miss the obj folder. 
Try compile the program and the obj folder will be generated, then the errors should dissapear.

## Nuget packages
Remember to download following nuget packages:
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Swashbuckle.AspNetCore
- dotnet add package Swashbuckle.AspNetCore.Swagger
- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
- dotnet add package Microsoft.Extensions.Logging
- dotnet add package Microsoft.Extensions.Logging.Console


## EF Core setup
Installs the Entity Framework Core (EF-Core) CLI (dotnet-ef) tool globally on your system
- dotnet tool install --global dotnet-ef

dotnet-ef: This is the name of the tool you are installing. dotnet-ef is the command-line tool for Entity Framework Core, 
used for tasks like creating migrations, updating the database, and scaffolding a database context.

## Database setup
### Setting up an SQL Server with Docker
Pull the sql image with the following command:
- docker pull mcr.microsoft.com/mssql/server:2022-latest

Run the SQL Server Container
- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrongPassword!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

Check if sql server is running in docker desktop or run this command:
- docker ps

## Connecting to SQL Server from Azure Data Studio
- Click 'New Connection'

Enter the following connection details:
Server: localhost,1433
Authentication Type: SQL Login
Username: sa
Password: YourStrongPassword!

Click 'Connect'.

<img src="./doc/Screenshots/Azuredatastudio.png" alt="Azuredatastudio" width="400"/>

## Creating a Database
Once connected, you can create a new database using a SQL Query:

- CREATE DATABASE FoodApp

<img src="./doc/Screenshots/newquery.png" alt="newquery" width="400"/>

<img src="./doc/Screenshots/createdatabase.png" alt="createdatabase" width="400"/>

## Generate C# Code based on current database schema with scaffolding tool
### This part is not needed to do, since it's already done!
If you are interested in how to do it, see the following.
Install the code generator tool
- dotnet tool install --global dotnet-aspnet-codegenerator

Run the scaffold command to genereate models and Dbcontext
- dotnet ef dbcontext scaffold "Data Source=localhost,1433;Database=FoodApp;User Id=sa;Password=YourStrongPassword!;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models

If you want to test it out and delete your current Models and DbContext then you can use the following command at the end of the scaffold command
--force

Run the scaffold command to generate controllers (These do not generate good code for RESTful API)
- dotnet aspnet-codegenerator controller -name YourControllerName -m YourModelName -dc YourDbContextName -outDir Controllers

## Migration













