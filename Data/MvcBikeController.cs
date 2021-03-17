using Microsoft.EntityFrameworkCore;
using DublinBike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DublinBike.Data
{
    public class MvcBikeContext : DbContext
    {
        public MvcBikeContext(DbContextOptions<MvcBikeContext> options) : base(options)
        {

        }

        public DbSet<Bike> Bike {get; set;}

    }
}
