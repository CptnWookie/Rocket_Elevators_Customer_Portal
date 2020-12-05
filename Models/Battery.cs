using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Battery
        {
            public int Id { get; set; }
            public int buildingId { get; set; }
            public object employeeId { get; set; }
            public string batteryType { get; set; }
            public string batteryStatus { get; set; }
            public DateTime dateOfCommissioning { get; set; }
            public DateTime dateOfLastInspection { get; set; }
            public string certificateOfOperations { get; set; }
            public string information { get; set; }
            public string notes { get; set; }
            
            public List<Column> columns { get; set; }
            public Building Building { get; set; }
        }
}

        