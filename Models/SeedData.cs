using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DublinBike.Data;
using System;
using System.Linq;

namespace DublinBike.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBikeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcBikeContext>>()))
            {
                // Look for any movies.
                if (context.Bike.Any())
                {
                    return;   // DB has been seeded
                }

                context.Bike.AddRange(
                    new Bike
                    {
                        ContractName = "Dublin",
                        Name = "Pearse St",
                        Address = "",
                        Latitude = 45.345678M,
                        Longitude = 88.2766M,
                        Banking = true,
                        AvailableBikes = 67,
                        AvailableStands = 45,
                        Capacity = 130,
                        Status = "OPEN",
                    },

                    new Bike
                    {
                        ContractName = "Dublin",
                        Name = "Mayor Street Upper",
                        Address = "",
                        Latitude = 56.345M,
                        Longitude = 35.7809M,
                        Banking = false,
                        AvailableBikes = 78,
                        AvailableStands = 95,
                        Capacity = 200,
                        Status = "CLOSE",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}