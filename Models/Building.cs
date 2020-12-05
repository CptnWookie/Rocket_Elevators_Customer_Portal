using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Building
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? AdminContactId { get; set; }
        public long? TechnicalContactId { get; set; }
        public string AdministratorFullName { get; set; }
        public string AdministratorEmail { get; set; }
        public string AdministratorPhoneNumber { get; set; }
        public string TechnicalContactFullName { get; set; }
        public string TechnicalContactEmail { get; set; }
        public string TechnicalContactPhone { get; set; }
        public long? BuildingDetailId { get; set; }
        public long? AddressId { get; set; }

        public List<Battery> batteries { get; set; }
        public Customer customer { get; set; }
   
    }
}