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
        do that

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _logService.GetAllLogsAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LogEntry log) =>
            Ok(await _logService.CreateLogAsync(log));
    }
}