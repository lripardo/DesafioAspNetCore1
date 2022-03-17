#nullable disable
using Microsoft.EntityFrameworkCore;

public class RazorPagesTruckContext : DbContext
{
    public RazorPagesTruckContext(DbContextOptions<RazorPagesTruckContext> options)
        : base(options)
    {
    }

    public DbSet<DesafioAspNetCore1.Models.Truck> Truck { get; set; }
}