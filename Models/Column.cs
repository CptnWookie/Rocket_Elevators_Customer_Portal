using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Column
        {
            public long Id { get; set; }
            public long? BatteryId { get; set; }
            public string ColumnType { get; set; }
            public string ColumnStatus { get; set; }
            public int? NumberOfFloorsServed { get; set; }
            public string Information { get; set; }
            public string Notes { get; set; }
            
            public List<Elevator> elevators { get; set; }
            public Battery Battery { get; set; }
        }
}
        