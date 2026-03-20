namespace IncidentSimulator.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "UP"; // UP or DOWN
        public DateTime LastChecked { get; set; } = DateTime.Now;
    }


}