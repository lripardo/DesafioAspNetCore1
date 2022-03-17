#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioAspNetCore1.Models;

    public class RazorPagesTruckContext : DbContext
    {
        public RazorPagesTruckContext (DbContextOptions<RazorPagesTruckContext> options)
            : base(options)
        {
        }

        public DbSet<DesafioAspNetCore1.Models.Truck> Truck { get; set; }
    }
