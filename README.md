# ASP.NET Core web API development template
This template was initially made for an assignment in Aarhus University.

## Rules for this repo
- Don't commit alot of code
- Clean commits, with short descriptive text
- If working in main branch, don't use 'git add .'!

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

<img src="./doc/Screenshots/appsettings.png" alt="serverExplorer" width="800"/>

Add the following in the file: 'program.cs'

<img src="./doc/Screenshots/programcs.png" alt="serverExplorer" width="600"/>

Now you have connected your application to the database!

## Generate C# Code based on current database schema with scaffolding tool
### This part is not needed to do, since it's already done!
If you are interested in how to do it, see the following.

- Find your connection string (See: 'Find your connection string with Visual Studio')

Run the scaffold command to genereate models and Dbcontext
- dotnet ef dbcontext scaffold "Data Source=localhost,1433;Database=FoodApp;User Id=sa;Password=YourStrongPassword!;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models

If you want to test it out and delete your current Models and DbContext then you can use the following command at the end of the scaffold command
--force

## Migration
in Entity Framework Core a migration generates a new migration file that represents the changes needed to create or update the database schema based on your current model.
Basically every time you want to create a new table, or add a new seed function or similar, you need to run a migration to update the database with the new changes.

- dotnet ef migrations add <MigrationName>

To apply the new changes to the database, you need to run the following command:
- dotnet ef database update

## Serilog Setup in ASP.NET Core
### Step 1: Add Serilog NuGet Packages
- Serilog.AspNetCore
- Serilog.Sinks.MSSqlServer

### Step 2: Configure Serilog in program.cs
Add following namespaces:
using Serilog; // Add Serilog namespace
using Serilog.Sinks.MSSqlServer; // Required for MSSQL sink

Step-by-Step Placement in Program.cs

1. Add the Serilog Setup: Add Serilog setup before creating the WebApplication builder.
2. Replace Default Logger: Configure builder.Host.UseSerilog(...) to replace the default logger.
3. Close the Logger: Ensure the logger is closed properly when the application shuts down.

Add the following code to program.cs
```csharp
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
    .WriteTo.File(
        "Logs/log.txt",
        outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] [MachineName #{ThreadId}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day
    )
    .WriteTo.MSSqlServer(
        connectionString: new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "LogEvents",
            AutoCreateSqlTable = true
        }
    )
    .CreateLogger();
```
See file program.cs to see how serilog is configured.

## Adding Serilog enrichers

### Step 1: Add Serilog Enrichers NuGet Packages
- Serilog.Enrichers.Environment
- Serilog.Enrichers.Thread

### Step 2: Activate the enrichers
Configure the enrichers in program.cs before building the application

```csharp
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration);
    lc.Enrich.WithMachineName();
    lc.Enrich.WithThreadId();
    lc.WriteTo.File(
        "Logs/log.txt",
        outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day
    );
});
```

Now we have enhanced our application with Enrichers

With the WithMachineName and WithThreadId enrichers:
Every log entry includes the machine name where the application is running, useful in distributed systems or multi-server environments.
Each log entry also has the thread ID from which it originated, which is helpful for debugging multithreaded applications.

## Setting Up ASP.NET with a Website: SignalR vs. RESTful API
Missing documentation

## Setting up MongoDB with docker
### Step 1: Pull the MongoDB docker image
- docker pull mongo

### Step 2: Run the MongoDB docker container
- docker run -d --name mongo1 -p 27017:27017 mongo

### Step 3: Setup graphical interface for MongoDB Database with MongoDB Compass
- Download MongoDB Compass: https://www.mongodb.com/try/download/compass

If you prefer working with the terminal, then use the following link:
- CLI tools: https://www.mongodb.com/try/download/database-tools

















