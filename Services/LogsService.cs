using IncidentSimulator.Data;
using IncidentSimulator.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentSimulator.Services
{
    public class LogService
    {
        private readonly AppDbContext _context;

        public LogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LogEntry>> GetAllLogsAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<LogEntry> CreateLogAsync(LogEntry log)
        {
            log.Timestamp = DateTime.UtcNow;
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }
    }
}