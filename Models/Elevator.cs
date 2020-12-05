using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Elevator
        {
            public long Id { get; set; }
            public long? ColumnId { get; set; }
            public string SerialNumber { get; set; }
            public string ElevatorModel { get; set; }
            public string ElevatorType { get; set; }
            public string ElevatorStatus { get; set; }
            public DateTime? DateOfCommissioning { get; set; }
            public DateTime? DateOfLastInspection { get; set; }
            public string CertificateOfInspection { get; set; }
            public string Information { get; set; }
            public string Notes { get; set; }
            
            public Column Column { get; set; }
        }
}