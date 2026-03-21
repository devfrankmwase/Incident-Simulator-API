using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Data;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLogs(string? level)
        {
            var logs = DataStore.Logs.AsQueryable();
            if(!string.IsNullOrEmpty(level))
            {
                logs = logs.Where(l => l.Level.ToLower() == level.ToLower());
            }
            return Ok(logs.ToList());
        }
    }
}