using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;

public class HttpMethodEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpMethodEnricher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var httpMethod = _httpContextAccessor.HttpContext?.Request.Method ?? "Unknown";
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("HttpMethod", httpMethod));
    }
}
