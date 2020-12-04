using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Net;
using System.IO;
using Rocket_Elevators_Customer_Portal.Models;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portal()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public class Customers
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
        }

        public partial class Employees
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
         

        public IActionResult BatteriesList()
        {
            return View();
        }

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

        public IActionResult ColumnsList()
        {
            return View();
        }

        public class Columns
        {
            public long Id { get; set; }
            public long? BatteryId { get; set; }
            public string ColumnType { get; set; }
            public string ColumnStatus { get; set; }
            public int? NumberOfFloorsServed { get; set; }
            public string Information { get; set; }
            public string Notes { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public IActionResult ElevatorsList()
        {
            return View();
        }

        public class Elevators
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
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public IActionResult Interventions()
        {

            string url1 = "https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries";
            WebRequest request = HttpWebRequest.Create(url1);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string Customer_JSON_List = reader.ReadToEnd();
            List<Batteries> BList = new List<Batteries>();
            List<Batteries> objResponse =
            JsonConvert.DeserializeObject<List<Batteries>>(Customer_JSON_List);
            return View();
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
