using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Employee
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Function { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public long? UserId { get; set; }
        }
}