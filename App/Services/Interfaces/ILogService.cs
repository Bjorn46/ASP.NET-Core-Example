using Assignment2.Models;

namespace Assignment2.Services.Interfaces
{
    public interface ILogService
    {
        IEnumerable<LogEntry> SearchLogs(string user, DateTime? startDate, DateTime? endDate, string operation);
    }
}
