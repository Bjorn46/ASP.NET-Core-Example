using Assignment2.Models;
using Assignment2.Services.Interfaces;
using MongoDB.Driver;

namespace Assignment2.Services
{
    public class LogService : ILogService
    {
        private readonly IMongoCollection<LogEntry> _logs;

        public LogService(IMongoDatabase database)
        {
            _logs = database.GetCollection<LogEntry>("logs");
        }

        public IEnumerable<LogEntry> SearchLogs(string email, DateTime? startDate, DateTime? endDate, string httpMethod)
        {
            var filterBuilder = Builders<LogEntry>.Filter;
            var filter = filterBuilder.Empty;

            // Filter by email
            if (!string.IsNullOrEmpty(email))
            {
                filter &= filterBuilder.Eq(log => log.Properties.Email, email);
            }

            // Filter by timestamp range
            if (startDate.HasValue && endDate.HasValue)
            {
                filter &= filterBuilder.Gte(log => log.Timestamp, startDate.Value) &
                          filterBuilder.Lte(log => log.Timestamp, endDate.Value);
            }

            // Filter by http method type
            if (!string.IsNullOrEmpty(httpMethod))
            {
                filter &= filterBuilder.Eq(log => log.Properties.LogInfo.HttpMethod, httpMethod);
            }

            return _logs.Find(filter).ToList();
        }
    }
}
