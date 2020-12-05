using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Customer
        {
            public long Id { get; set; }
            public long? UserId { get; set; }
            public string CompanyName { get; set; }
            public string CompanyContactFullName { get; set; }
            public string CompanyContactPhone { get; set; }
            public string CompanyContactEmail { get; set; }
            public string CompanyDescription { get; set; }
            public string TechnicalAuthorityFullName { get; set; }
            public string TechnicalAuthorityPhoneNumber { get; set; }
            public string TechnicalManagerEmailService { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public long? AddressId { get; set; }

            public List<Building> buildings { get; set; }
        }
}