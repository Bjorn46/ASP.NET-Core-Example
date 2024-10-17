# Question and Answers
Write your questions about the code or other related topics. This will help us
better understand the code and the assignment.

## What is a connection string?
A connection string is a string used by applications to specify how to connect to a particular database
or data source. It contains all the necessary information, such as the server address, database name, user credentials, 
and other options required for establishing a connection to the database.

## What does the builder do in programcs?
The builder.Services object is used to configure all the services that your application will use, such as adding controllers, database context, authentication, logging, etc

## What is REST API
A REST API (Representational State Transfer Application Programming Interface) is a set of rules and conventions for building and interacting with web services. It allows communication between a client (eg., a web browser, mobile app) and a server over the web, typically using HTTP. REST API's are widely used in modern web and mobile applications because of their simplicity, scalability and flexibility.

Stateless: Each request from the client to the server must contain all the information the server needs to fulfill the request, without relying on any stored context on the server.

Resources: In REST, resources (like users, orders, products) are identified using URLs (Uniform Resource Locators). For example, in a REST API for a shopping site, a resource representing an order might be accessible via /orders/123.

HTTP Methods: REST APIs use standard HTTP methods to perform operations on resources:

    GET: Retrieve data from the server (e.g., fetch a list of products).
    POST: Send data to the server to create a new resource (e.g., create a new user).
    PUT: Update an existing resource (e.g., update a user's information).
    DELETE: Remove a resource (e.g., delete a product).

JSON or XML: REST APIs commonly use JSON (JavaScript Object Notation) or XML (Extensible Markup Language) to exchange data between client and server.

URI (Uniform Resource Identifier): Each resource in a REST API is accessed using a unique URI, which helps in organizing and accessing resources clearly. For example:

    /users: Accesses a collection of users.
    /users/123: Accesses a specific user with ID 123.

## What is model binding?
Model binding is a process used in web frameworks like ASP.NET to automatically map data from HTTP requests (such as form inputs, query parameters, or route data) to parameters in controller action methods or model objects. It simplifies the task of handling user input by converting it into objects that can be directly used in the application code.

## What do Scaffolding tools do?
Scaffolding tools are used in software development frameworks (such as ASP.NET Core, Django, and Ruby on Rails) to automatically generate boilerplate code for basic CRUD (Create, Read, Update, Delete) operations. The goal of scaffolding is to speed up development by providing a starting point for common functionalities, reducing the need for manual coding.

Scaffolding in ASP.NET Core (C#)

In ASP.NET Core, scaffolding tools can generate:

    Controllers: To handle HTTP requests (e.g., GET, POST, PUT, DELETE) related to a specific entity.

    Views: Razor Pages or MVC Views to display and handle user input (HTML forms).

    Data Access Code: The code that interacts with a database, often using Entity Framework.

Example:
If we have an existing SQL Database, we can then genereate models, DbContext, controllers with the scaffolding tool.

## What is migration?
Migrations in Entity Framework (EF) are a way to manage changes to your database schema over time in a structured and version-controlled manner. Here is an overview of what migrations are and why they are used:
What Are Migrations?
    Schema Changes: Migrations are used to apply changes to the database schema, such as creating new tables, modifying existing ones, or removing them.
    Automatic Updates: Migrations allow you to automatically generate the necessary SQL commands to update your database schema based on changes in your model classes (e.g., adding a property to a model class results in a new column in the database).
    Easy Rollback: If a migration introduces a problem, you can easily revert to a previous migration, restoring the database to its prior state.

See README.md document for how to use migration in your project.