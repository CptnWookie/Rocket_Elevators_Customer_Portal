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

        // This will get all the batteries for a Customer based on the CustomerId using the REST API and the endpoint created.
        public IActionResult BatteriesList(string email)
        {
            // http response for batteries
            HttpClient battclient = new HttpClient();
            var resbatt = battclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries/Buildings/1").GetAwaiter().GetResult();
            Console.WriteLine(resbatt);

            List<Battery> batt = JsonConvert.DeserializeObject<List<Battery>>(resbatt);

            ViewBag.batteries = batt;

            return View();
        }

        // This will get all the columns for a Customer based on the CustomerId using the REST API and the endpoint created.
        public IActionResult ColumnsList()
        {
            HttpClient colclient = new HttpClient();
            var rescol = colclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Columns/Batteries/1").GetAwaiter().GetResult();
            Console.WriteLine(rescol);

            List<Column> col = JsonConvert.DeserializeObject<List<Column>>(rescol);

            ViewBag.columns = col;

            return View();
        }

        // This will get all the elevators for a Customer based on the CustomerId using the REST API and the endpoint created.
        public IActionResult ElevatorsList()
        {
            HttpClient elevclient = new HttpClient();
            var reselev = elevclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Elevators/Columns/1").GetAwaiter().GetResult();
            Console.WriteLine(reselev);

            List<Elevator> elv = JsonConvert.DeserializeObject<List<Elevator>>(reselev);

            ViewBag.elevators = elv;

            return View();
        }

        // This will get all the products of a Customer based on the CustomerId using the REST API and the endpoint created.
        public IActionResult Interventions()
        {
            // This gets the buildings of the customer
            HttpClient client = new HttpClient();
            var resbuild = client.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/BuildingsOff/Customers/1").GetAwaiter().GetResult();
            Console.WriteLine(resbuild);

            List<Building> intmess = JsonConvert.DeserializeObject<List<Building>>(resbuild);

            ViewBag.intMessage = intmess;

            // This gets the batteries of the customer
            HttpClient battclient = new HttpClient();
            var resbatt = battclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Batteries/Buildings/1").GetAwaiter().GetResult();
            Console.WriteLine(resbatt);

            List<Battery> intbatt = JsonConvert.DeserializeObject<List<Battery>>(resbatt);

            ViewBag.intbatteries = intbatt;

            // This gets the columns of the customer
            HttpClient colclient = new HttpClient();
            var rescol = colclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Columns/Batteries/1").GetAwaiter().GetResult();
            Console.WriteLine(rescol);

            List<Column> intcol = JsonConvert.DeserializeObject<List<Column>>(rescol);

            ViewBag.intcolumns = intcol;

            // This gets the elevators of the customer
            HttpClient elevclient = new HttpClient();
            var reselev = elevclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Elevators/Columns/1").GetAwaiter().GetResult();
            Console.WriteLine(reselev);

            List<Elevator> intelev = JsonConvert.DeserializeObject<List<Elevator>>(reselev);

            ViewBag.intelevators = intelev;

            return View();


            // This gets the employees
            HttpClient emplclient = new HttpClient();
            var resempl = elevclient.GetStringAsync("https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Employees").GetAwaiter().GetResult();
            Console.WriteLine(resempl);

            List<Employee> intempl = JsonConvert.DeserializeObject<List<Employee>>(resempl);

            ViewBag.intemployees = intempl;

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
