using IncidentSimulator.Models;
using System.Collections.Generic;

namespace IncidentSimulator.Data
{
    public static class DataStore
    {
        public static List<ServiceModel> Services { get; set; } = new List<ServiceModel>();
        public static List<IncidentModel> Incidents { get; set; } = new List<IncidentModel>();
        public static List<LogEntry> Logs { get; set; } = new List<LogEntry>();
    }
}