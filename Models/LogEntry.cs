namespace IncidentSimulator.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; } // INFO, ERROR
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}