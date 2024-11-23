# HTTPContextAccessor in ASP.NET Core

```csharp
using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class EmailEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    // Constructor injection for IHttpContextAccessor
    public EmailEnricher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // The Enrich method adds custom properties to the log event
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        // Access the current HttpContext and extract the user's email from claims
        var email = _httpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "Unknown Email";

        // Add the email as a property to the log event
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Email", email));
    }
}
```

## How This Code Works:

- Constructor Injection:
The EmailEnricher class takes IHttpContextAccessor as a dependency in its constructor. This allows the enricher to access the current HTTP context.

- Enrich Method:
1. The Enrich method is implemented from the ILogEventEnricher interface. It is called each time a log event is created, and it enriches the log event with additional data.
2. Inside the Enrich method, we retrieve the user's email from the HttpContext.User.Claims collection. If the email claim is found, it is added to the log event; otherwise, it uses a default value of "Unknown Email".
3. The AddPropertyIfAbsent method ensures that the "Email" property is only added if it doesn't already exist.

- Accessing HttpContext:
1. HttpContext is accessed via IHttpContextAccessor, which provides a way to retrieve the context outside the typical controller or middleware scope.
2. This allows the EmailEnricher to access user information in services or other areas where HttpContext is not directly available.

## Benefits of This Approach:

- Centralized Logging: Every log event will automatically include the current user's email without needing to manually add this information in each log call.
- Contextual Logs: Adding user-specific data to logs enhances the context of your logs, making it easier to track and debug issues related to specific users.
- Reusability: The custom enricher can be reused throughout the application wherever Serilog is used for logging.

## How to Use EmailEnricher in Your ASP.NET Core Application:

1. Register IHttpContextAccessor and EmailEnricher:
In your Program.cs, register the IHttpContextAccessor and the EmailEnricher so they can be injected into your application.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Register IHttpContextAccessor for dependency injection
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    // Register the custom enricher as a singleton
    services.AddSingleton<ILogEventEnricher, EmailEnricher>();
}
```

2. Configure Serilog to Use the Custom Enricher:
In your Program.cs, configure Serilog to use the custom enricher.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure Host to use serilog (Reads from appsettings.json)
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration) // Reads configuration from appsettings.json
      .Enrich.With(new EmailEnricher(new HttpContextAccessor())) // Custom email enricher
      .Enrich.With(new HttpMethodEnricher(new HttpContextAccessor())); // Custom http method enricher
});
```

# Now to the more individual parts of the code
## Components:

```csharp
var email = _httpContextAccessor.HttpContext?.User.Claims
    .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "Unknown Email";
```

- _httpContextAccessor.HttpContext:
        _httpContextAccessor is an instance of IHttpContextAccessor, which allows access to the current HTTP request and its associated context outside of controllers or middleware.
        HttpContext represents the current HTTP request and response. This includes all request details, headers, cookies, and the user (if authenticated).
        HttpContext is nullable, meaning it could be null if there is no active HTTP context (e.g., in background tasks or certain parts of the application).

- ?. (Null-conditional operator):
        The ?. is called the null-conditional operator.
        It ensures that if _httpContextAccessor.HttpContext is null, the subsequent code is not executed, preventing a NullReferenceException. If HttpContext is null, it short-circuits and returns null for the entire expression.
        In this case, it ensures that if there is no HTTP context (e.g., outside of a web request), it doesn’t attempt to access HttpContext.User.

- HttpContext.User.Claims:
        HttpContext.User represents the currently authenticated user. It contains information about the user, typically from the authentication system (like ASP.NET Core Identity, JWT tokens, or cookies).
        Claims is a collection of Claim objects associated with the authenticated user. Claims are key-value pairs that represent user-specific data, such as their email, roles, and other attributes.
        Claims is a list of Claim objects, and we are looking for the claim of type ClaimTypes.Email, which represents the email of the user.

- .FirstOrDefault(c => c.Type == ClaimTypes.Email):
        FirstOrDefault() is a LINQ method that searches through the collection (Claims) and returns the first claim where the condition c.Type == ClaimTypes.Email is met. This checks for the first claim with the type of Email.
        If no such claim is found, FirstOrDefault() will return null.

- ?.Value:
        After using FirstOrDefault(), ?. is again used to safely access the Value property of the Claim object.
        If FirstOrDefault() returns null (meaning no claim of type Email was found), the ?.Value will safely return null as well, avoiding a NullReferenceException.

- ?? "Unknown Email":
        The ?? is the null-coalescing operator.
        If the expression on the left-hand side is null, the operator will return the value on the right-hand side as a fallback.
        If the email claim is not found (i.e., FirstOrDefault() returns null or ?.Value is null), "Unknown Email" will be assigned to the email variable as a default value.

```csharp
logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Email", email));
```

Adds a custom property (in this case, Email) to a Serilog log event. Let's break it down to understand what each part does:
Breakdown of the Code:

- logEvent:
        This represents the log event that is being created or logged. A LogEvent in Serilog contains information such as the log message, the log level (e.g., Information, Error), timestamp, and any associated properties (key-value pairs).
        A log event can have one or more properties that provide additional contextual information about the event, such as user details, request IDs, or error codes.

- AddPropertyIfAbsent:
        This is a method of the LogEvent class in Serilog. It adds a property to the log event only if that property doesn't already exist.
        This is useful to avoid adding the same property multiple times (in case an enricher or another part of your code tries to add the same property again).
        The method takes a LogEventProperty and adds it to the Properties collection of the log event.
        If the property with the same name already exists, it will not add it again, ensuring that you don’t inadvertently duplicate information.

- propertyFactory.CreateProperty("Email", email):
        propertyFactory is an instance of ILogEventPropertyFactory, which is used to create LogEventProperty objects (the key-value pairs that represent properties in a log event).
        The CreateProperty method is used to create a new property.
            The first argument is the name of the property, in this case, "Email".
            The second argument is the value of the property, which in this case is the value of the email variable (this could be the email of the currently authenticated user, or "Unknown Email" if no email is found).
        This will create a new LogEventProperty with the name "Email" and the value that is stored in the email variable.

