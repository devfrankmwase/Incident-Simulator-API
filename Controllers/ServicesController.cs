using Microsoft.AspNetCore.Mvc;
using IncidentSimulator.Data;
using IncidentSimulator.Models;
using System.Linq;

namespace IncidentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetServices()
        {
            return Ok(DataStore.Services);
        }

        [HttpPost]
        public IActionResult AddService(ServiceModel service)
        {
            service.Id = DataStore.Services.Count + 1;
            service.LastChecked = DateTime.Now;
            DataStore.Services.Add(service);

            return Ok(service);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = DataStore.Services.FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            DataStore.Services.Remove(service);

            return NoContent(); // 204 success
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, ServiceModel updatedService)
        {
            var service = DataStore.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            } 

            service.Name = updatedService.Name;
            service.Status = updatedService.Status;
            service.LastChecked = DateTime.Now;

            // Automatic incident creation
            if (service.Status == "DOWN")
            {
                var incidentExists = DataStore.Incidents.Any(i => i.ServiceId == service.Id && i.Status == "OPEN");
                if (!incidentExists)
                {
                    DataStore.Incidents.Add(new IncidentModel
                    {
                        Id = DataStore.Incidents.Count + 1,
                        ServiceId = service.Id,
                        ServiceName = service.Name,
                        Severity = GetSeverity(service.Name),
                        CreatedAt = DateTime.Now,
                        Status = "OPEN",
                        ResolvedAt = null
                    });
                }
            }

            if (service.Status == "UP")
            {
                var openIncident = DataStore.Incidents
                    .FirstOrDefault(i => i.ServiceId == service.Id && i.Status == "OPEN");

                if (openIncident != null)
                {
                    openIncident.Status = "RESOLVED";
                    openIncident.ResolvedAt = DateTime.Now;
                }
            }

            return Ok(service);
        }

        private string GetSeverity(string serviceName)
        {
            if (serviceName.Contains("Database"))
                return "HIGH";

            if (serviceName.Contains("Payment"))
                return "HIGH";

            if (serviceName.Contains("Auth"))
                return "MEDIUM";

            return "LOW";
        }
    }
}


           