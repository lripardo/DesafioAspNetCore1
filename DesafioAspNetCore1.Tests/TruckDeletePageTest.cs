using System.Threading.Tasks;
using DesafioAspNetCore1.Models;
using DesafioAspNetCore1.Pages.Trucks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xunit;

namespace DesafioAspNetCore1.Tests;

public class TruckDeletePageTest : TruckPageTest
{
    [Fact]
    public async Task OnGetAsyncTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();
        var truck = new Truck(200);
        db.Truck.Add(truck);
        await db.SaveChangesAsync();

        var pageModel = new DeleteModel(db)
        {
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        var result1 = await pageModel.OnGetAsync(null);
        Assert.IsType<NotFoundResult>(result1);

        var result2 = await pageModel.OnGetAsync(1);
        Assert.IsType<NotFoundResult>(result2);

        var result3 = await pageModel.OnGetAsync(truck.ID);
        Assert.IsType<PageResult>(result3);
    }
}