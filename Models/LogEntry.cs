namespace IncidentSimulator.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public required string Message { get; set; }
        public required string Level { get; set; } // INFO, WARNING, ERROR
        public required DateTime Timestamp { get; set; }
    }
}