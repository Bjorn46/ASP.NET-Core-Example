using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Assignment2.Services;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService LogService)
        {
            _logService = LogService;
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<LogEntry>> SearchLogs(
            [FromQuery] string email = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] string httpMethod = null)
        {
            try
            {
                var logs = _logService.SearchLogs(email, startDate, endDate, httpMethod);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while searching logs.", Details = ex.Message });
            }
        }
    }
}
