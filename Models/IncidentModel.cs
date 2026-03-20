using System;

namespace IncidentSimulator.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }               // Unique ID
        public int ServiceId { get; set; }        // Link to the service
        public string ServiceName { get; set; }   // For easier reading
        public string Severity { get; set; }      // LOW, MEDIUM, HIGH
        public DateTime CreatedAt { get; set; }   // When incident was created
        public string Status { get; set; }        // OPEN or RESOLVED

        public DateTime? ResolvedAt { get; set; }
    }
}