using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Models;
using IncidentSimulator.Services;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IncidentService _incidentService;

        public IncidentsController(IncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _incidentService.GetAllIncidentsAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncidentModel incident) =>
            Ok(await _incidentService.CreateIncidentAsync(incident));

        [HttpPut("{id}/resolve")]
        public async Task<IActionResult> Resolve(int id)
        {
            var incident = await _incidentService.ResolveIncidentAsync(id);
            if (incident == null) return NotFound();
            return Ok(incident);
        }
    }
}