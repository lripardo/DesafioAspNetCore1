using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioAspNetCore1.Tests;

public class TruckPageTest
{
    protected readonly DbContextOptions<RazorPagesTruckContext> Options;

    protected TruckPageTest()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        Options = new DbContextOptionsBuilder<RazorPagesTruckContext>()
            .UseInMemoryDatabase("InMemoryDb")
            .UseInternalServiceProvider(serviceProvider).Options;
    }
}