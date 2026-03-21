using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Models;
using IncidentSimulator.Services;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _serviceService.GetAllServicesAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceModel service) =>
            Ok(await _serviceService.CreateServiceAsync(service));

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var service = await _serviceService.UpdateServiceStatusAsync(id, status);
            if (service == null) return NotFound();
            return Ok(service);
        }
    }
}