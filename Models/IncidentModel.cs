using System;

namespace IncidentSimulator.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }               // Unique ID
        public required int ServiceId { get; set; }        // Link to the service
        public required string ServiceName { get; set; }   // For easier reading
        public required string Severity { get; set; }      // LOW, MEDIUM, HIGH
        public required DateTime CreatedAt { get; set; }   // When incident was created
        public required string Status { get; set; }        // OPEN or RESOLVED

        public required DateTime? ResolvedAt { get; set; }
    }
}