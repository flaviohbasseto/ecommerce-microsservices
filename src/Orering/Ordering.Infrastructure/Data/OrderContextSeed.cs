using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderCotext, ILoggerFactory loggerFactory, int? retry = 0)
        {

            int retryForAvaibility = retry.Value;

            try
            {
                orderCotext.Database.Migrate();

                if (!orderCotext.Orders.Any())
                {
                    orderCotext.Orders.AddRange(GetPreconfiguredOrders());

                    await orderCotext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvaibility < 3)
                {
                    retryForAvaibility++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(orderCotext, loggerFactory, retryForAvaibility);
                }
            }
        }

        public static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() 
                {
                    UserName = "Swn", 
                    FirstName = "Mehmet", 
                    LastName = "Ozkaya", 
                    EmailAdress = "ezozkme@gmail.com", 
                    AdressLine = "Bahceliever", 
                    Country = "Turkey"
                },
                new Order()
                {
                    UserName = "bassetoflavio",
                    FirstName = "Flavio",
                    LastName = "Basseto",
                    EmailAdress = "flavio.basseto03@gmail.com",
                    AdressLine = "Rua Elias Antonio",
                    Country = "Brazil"
                }
            };
        }
    }
}
