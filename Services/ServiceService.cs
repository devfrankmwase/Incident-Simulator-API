using IncidentSimulator.Data;
using IncidentSimulator.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentSimulator.Services
{
    public class ServiceService
    {
        private readonly AppDbContext _context;

        public ServiceService(AppDbContext context)
        {
            _context = context;
        }

        // Get all services
        public async Task<List<ServiceModel>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        // Create service + log creation
        public async Task<ServiceModel> CreateServiceAsync(ServiceModel service)
        {
            service.LastChecked = DateTime.UtcNow;
            _context.Services.Add(service);

            // Log service creation
            var log = new LogEntry
            {
                Message = $"Service '{service.Name}' created with status '{service.Status}'.",
                Level = "Info",
                Timestamp = DateTime.UtcNow
            };
            _context.Logs.Add(log);

            await _context.SaveChangesAsync();
            return service;
        }

        // Update service status + log change
        public async Task<ServiceModel?> UpdateServiceStatusAsync(int id, string status)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return null;

            var oldStatus = service.Status;
            service.Status = status;
            service.LastChecked = DateTime.UtcNow;

            // Log status change
            var log = new LogEntry
            {
                Message = $"Service '{service.Name}' status changed from '{oldStatus}' to '{status}'.",
                Level = "Info",
                Timestamp = DateTime.UtcNow
            };
            _context.Logs.Add(log);

            await _context.SaveChangesAsync();
            return service;
        }
    }
}