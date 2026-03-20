using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Data;
using IncidentSimulator.Models;
using System.Linq;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetIncidents([FromQuery] string? status, [FromQuery] string? severity)
        {
            var incidents = DataStore.Incidents.AsEnumerable();

            if (!string.IsNullOrEmpty(status))
                incidents = incidents.Where(i => i.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(severity))
                incidents = incidents.Where(i => i.Severity.Equals(severity, StringComparison.OrdinalIgnoreCase));

            return Ok(incidents);
        }
        [HttpPut("{id}/resolve")]
        public IActionResult ResolveIncident(int id)
        {
            var incident = DataStore.Incidents.FirstOrDefault(i => i.Id == id);
            if (incident == null) return NotFound();

            incident.Status = "RESOLVED";
            return Ok(incident);
        }
    }
}