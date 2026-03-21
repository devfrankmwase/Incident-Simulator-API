using Microsoft.EntityFrameworkCore;
using IncidentSimulator.Models;

namespace IncidentSimulator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<IncidentModel> Incidents { get; set; }
        public DbSet<LogEntry> Logs { get; set; }
    }
}