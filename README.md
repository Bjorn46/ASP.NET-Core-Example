# BADassignment-2
Assignment two of backend development

## Resources for developing ASP.NET Core Applications
- RESTful web API design: https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design
- Create web APIs with ASP.NET Core: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0
- Generate or find connection string: https://www.c-sharpcorner.com/UploadFile/suthish_nair/how-to-generate-or-find-connection-string-from-visual-studio/

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

(Remember that this is part of your connection string that you will use later in your application to connect to the database)

Click 'Connect'.

<img src="./doc/Screenshots/Azuredatastudio.png" alt="Azuredatastudio" width="400"/>

## Creating a Database
Once connected, you can create a new database using a SQL Query:

- CREATE DATABASE FoodApp

<img src="./doc/Screenshots/newquery.png" alt="newquery" width="400"/>

<img src="./doc/Screenshots/createdatabase.png" alt="createdatabase" width="400"/>

## Connecting our application to the database with the connection string (in this case FoodApp).
First assemble your connection string
- "Data Source=localhost,1433;Database=FoodApp;User Id=sa;Password=YourStrongPassword!;TrustServerCertificate=True"

### Find your connection string with Visual Studio
Sometimes you might have created a database long ago, and you don't remember what your connection string is. There is alot of ways to find your connection string,
but one way of finding it, is with Visual Studio. See the following screenshots:

<img src="./doc/Screenshots/connectionString.png" alt="serverExplorer" width="400"/>

<img src="./doc/Screenshots/addConnection.png" alt="serverExplorer" width="400"/>

<img src="./doc/Screenshots/selectDatabase.png" alt="serverExplorer" width="400"/>

<img src="./doc/Screenshots/string.png" alt="serverExplorer" width="400"/>

### Add connection string to your ASP.NET Application
Add the following in the file: 'appsettings.json'

- <img src="./doc/Screenshots/appsettings.png" alt="serverExplorer" width="400"/>

Add the following in the file: 'program.cs'

- <img src="./doc/Screenshots/programcs.png" alt="serverExplorer" width="400"/>

Now you have connected your application to the database!

## Generate C# Code based on current database schema with scaffolding tool
### This part is not needed to do, since it's already done!
If you are interested in how to do it, see the following.

- Find your connection string (See: 'Find your connection string with Visual Studio')

Run the scaffold command to genereate models and Dbcontext
- dotnet ef dbcontext scaffold "Data Source=localhost,1433;Database=FoodApp;User Id=sa;Password=YourStrongPassword!;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models

If you want to test it out and delete your current Models and DbContext then you can use the following command at the end of the scaffold command
--force

Run the scaffold command to generate controllers (These do not generate good code for RESTful API)
- dotnet aspnet-codegenerator controller -name YourControllerName -m YourModelName -dc YourDbContextName -outDir Controllers

## Migration
in Entity Framework Core a migration generates a new migration file that represents the changes needed to create or update the database schema based on your current model.
Basically every time you want to create a new table, or add a new seed function or similar, you need to run a migration to update the database with the new changes.

- dotnet ef migrations add <MigrationName>

To apply the new changes to the database, you need to run the following command:
- dotnet ef database update














