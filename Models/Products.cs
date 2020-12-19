using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Rocket_Elevators_Customer_Portal.Models;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Products
    {
        private readonly ILogger<Products> _logger;
        private readonly HttpClient _httpClient = new HttpClient();
        public Products()
        {
            var serviceProvider = new ServiceCollection()
                      .AddLogging() //<-- You were missing this
                      .BuildServiceProvider();
            _logger = serviceProvider.GetService<ILoggerFactory>()
                        .CreateLogger<Products>();
        }
        // // ========== Function that calls endpoint /api/Customers/id to get all the data from the customer that is logged at the portal ============
        public Customer getFullCustomerInfo(string email)
        {
            var result = _httpClient.GetAsync("https://rocketrestapi.azurewebsites.net/api/Customers/" + email).Result;
            var contentBody = result.Content.ReadAsStringAsync().Result;
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            
            Customer customer = JsonConvert.DeserializeObject<Customer>(contentBody);
            customer.buildings.ForEach(building =>
            {
                building.customer = customer;
                building.batteries.ForEach(battery =>
                {
                    battery.Building = building;
                    battery.columns.ForEach(column =>
                    {
                        column.Battery = battery;
                        column.elevators.ForEach(elevator => 
                        {
                            elevator.Column = column;
                        });
                    });
                });
            });
            _logger.LogInformation("customer email: {}", customer.CompanyContactEmail);
            _logger.LogInformation("customer buildings: {}", customer.buildings);
            Console.WriteLine(" ============ all the CUSTOMER infos are here!!! ============ ");
            Console.WriteLine(customer.buildings.Count);
            return customer;
        }
        //------------------------------ TEST ------------------------------
        public void helloWorld() //Test
        {
            _logger.LogInformation("Hello World!!!");
            Console.WriteLine("Hello again");
        }
        //------------------------------------------------------------------
    }
}
