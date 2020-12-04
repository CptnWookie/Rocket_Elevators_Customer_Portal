using System;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Batteries
    {
        public int id { get; set; }
        public int buildingId { get; set; }
        public object employeeId { get; set; }
        public string batteryType { get; set; }
        public string batteryStatus { get; set; }
        public DateTime dateOfCommissioning { get; set; }
        public DateTime dateOfLastInspection { get; set; }
        public string certificateOfOperations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}