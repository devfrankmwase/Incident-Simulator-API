using IncidentSimulator.Data;
using IncidentSimulator.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentSimulator.Services
{
    public class IncidentService
    {
        private readonly AppDbContext _context;

        public IncidentService(AppDbContext context)
        {
            _context = context;
        }

        // Get all incidents
        public async Task<List<IncidentModel>> GetAllIncidentsAsync()
        {
            return await _context.Incidents.ToListAsync();
        }

        // Create incident + auto-log
        public async Task<IncidentModel> CreateIncidentAsync(IncidentModel incident)
        {
            incident.CreatedAt = DateTime.UtcNow;
            _context.Incidents.Add(incident);

            // Create a log entry
            var log = new LogEntry
            {
                Message = $"Incident created for service '{incident.ServiceName}' with severity '{incident.Severity}'.",
                Level = "Info",
                Timestamp = DateTime.UtcNow
            };
            _context.Logs.Add(log);

            await _context.SaveChangesAsync();
            return incident;
        }

        // Resolve incident + auto-log
        public async Task<IncidentModel?> ResolveIncidentAsync(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null) return null;

            incident.Status = "Resolved";
            incident.ResolvedAt = DateTime.UtcNow;

            // Create a log entry
            var log = new LogEntry
            {
                Message = $"Incident ID {incident.Id} for service '{incident.ServiceName}' resolved.",
                Level = "Info",
                Timestamp = DateTime.UtcNow
            };
            _context.Logs.Add(log);

            await _context.SaveChangesAsync();
            return incident;
        }
    }
}