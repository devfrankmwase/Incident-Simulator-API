using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Data;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLogs()
        {
            return Ok(DataStore.Logs);
        }
    }
}