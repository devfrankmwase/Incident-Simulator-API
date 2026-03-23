namespace IncidentSimulator.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; } = "UP"; // UP or DOWN
        public required DateTime LastChecked { get; set; } = DateTime.Now;
    }


}