#nullable disable
using Microsoft.EntityFrameworkCore;
using DesafioAspNetCore1.Models;

public class RazorPagesTruckContext : DbContext
{
    public RazorPagesTruckContext(DbContextOptions<RazorPagesTruckContext> options)
        : base(options)
    {
    }

    public DbSet<Truck> Truck { get; set; }
}