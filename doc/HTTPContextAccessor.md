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
var httpMethod = _httpContextAccessor.HttpContext?.Request.Method ?? "Unknown";

## Components:

- _httpContextAccessor.HttpContext:
        _httpContextAccessor is an instance of IHttpContextAccessor, which allows you to access the current HttpContext outside of controllers and middleware.
        HttpContext is an object that represents the current HTTP request and response, providing information such as headers, cookies, user claims, and much more.
        HttpContext is nullable, meaning it might be null if the HTTP context is not available, such as in background services or certain parts of the application where there is no active HTTP request.

- ?. (Null-conditional operator):
        This is called the null-conditional operator (also known as the safe navigation operator).
        It is used to safely access members or properties of an object that could be null. If the object (HttpContext in this case) is null, it prevents a NullReferenceException from being thrown and simply returns null instead.
        In this case, if _httpContextAccessor.HttpContext is null, it will short-circuit and not try to access .Request.Method, so the entire expression would evaluate to null.

- HttpContext.Request.Method:
        HttpContext.Request represents the current HTTP request.
        .Method is a property of Request that contains the HTTP method (like "GET", "POST", "PUT", "DELETE", etc.) used for the request.
        If the HttpContext is not null, this retrieves the HTTP method of the incoming request.

- ?? "Unknown":
        The ?? is the null-coalescing operator.
        It is used to provide a default value when the expression on the left-hand side is null.
        In this case, if _httpContextAccessor.HttpContext?.Request.Method is null (meaning there is no active HTTP context or the Request object is null), the expression will default to "Unknown".
        Essentially, this ensures that if the HTTP method is unavailable (e.g., in a non-request context), "Unknown" will be used instead of null.
