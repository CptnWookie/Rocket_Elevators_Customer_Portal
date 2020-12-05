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
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using Rocket_Elevators_Customer_Portal.Models;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using System.Web;





namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Products _products = new Products();
        private readonly UserManager<IdentityUser> _userManager; // Added/Injection UserManager to find the current logged user

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult BatteriesList()
        {
            // http response for batteries
            HttpClient battclient = new HttpClient();
            var resbatt = battclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries/Buildings/1").GetAwaiter().GetResult();
            // var resbatt = battclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries/1/Batteries").GetAwaiter().GetResult();
            Console.WriteLine(resbatt);

            List<Battery> k = JsonConvert.DeserializeObject<List<Battery>>(resbatt);

            ViewBag.batteries = k;
            
            return View();
        }

        public IActionResult ColumnsList()
        {
            HttpClient colclient = new HttpClient();
            var rescol = colclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Columns/Batteries/1").GetAwaiter().GetResult();
            Console.WriteLine(rescol);

            List<Column> l = JsonConvert.DeserializeObject<List<Column>>(rescol);

            ViewBag.columns = l;

            return View();
        }

        public IActionResult ElevatorsList()
        {
            HttpClient elevclient = new HttpClient();
            var reselev = elevclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Elevators/Columns/1").GetAwaiter().GetResult();
            Console.WriteLine(reselev);

            List<Elevator> m = JsonConvert.DeserializeObject<List<Elevator>>(reselev);

            ViewBag.elevators = m;

            return View();
        }

        public IActionResult Interventions()
        {
            //http response for building
            HttpClient client = new HttpClient();
            var resbuild = client.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/BuildingsOff/Customers/1").GetAwaiter().GetResult();
            Console.WriteLine(resbuild);

            List<Building> j = JsonConvert.DeserializeObject<List<Building>>(resbuild);

            ViewBag.intMessage = j;

            // http response for batteries
            HttpClient battclient = new HttpClient();
            var resbatt = battclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries/Buildings/1").GetAwaiter().GetResult();
            // var resbatt = battclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries/1/Batteries").GetAwaiter().GetResult();
            Console.WriteLine(resbatt);

            List<Battery> k = JsonConvert.DeserializeObject<List<Battery>>(resbatt);

            ViewBag.intbatteries = k;

            // http response for columns
            HttpClient colclient = new HttpClient();
            var rescol = colclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Columns/Batteries/1").GetAwaiter().GetResult();
            Console.WriteLine(rescol);

            List<Column> l = JsonConvert.DeserializeObject<List<Column>>(rescol);

            ViewBag.intcolumns = l;

            // http response for columns
            HttpClient elevclient = new HttpClient();
            var reselev = elevclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Elevators/Columns/1").GetAwaiter().GetResult();
            Console.WriteLine(reselev);

            List<Elevator> m = JsonConvert.DeserializeObject<List<Elevator>>(reselev);

            ViewBag.intelevators = m;

            return View();
        }

        // ========== Function to get all the data from the customer that is logged at the portal using the email ========================================
        // /Home/getFullCustomerInfo
        public IActionResult getFullCustomerInfo()
        {
            var user_email = _userManager.GetUserName(User);
            Console.WriteLine("email: " + user_email);
            var customer =  _products.getFullCustomerInfo(user_email);
            Console.WriteLine("Called getFullCustomerInfo");
            _logger.LogInformation(" !!! CALLED FUNCTION getFullCustomerInfo !!! ");
            return View("~/Views/Home/Products.cshtml", customer);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
