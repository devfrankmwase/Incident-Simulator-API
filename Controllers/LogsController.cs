using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Models;
using IncidentSimulator.Services;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly LogService _logService;

        public LogsController(LogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _logService.GetAllLogsAsync();
            return Ok(logs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LogEntry log)
        {
            var createdLog = await _logService.CreateLogAsync(log);
            return Ok(createdLog);
        }
    }
}