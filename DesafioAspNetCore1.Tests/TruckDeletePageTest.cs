using System.Linq;
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
        var truck = AddTruckOnDatabase(db);

        var pageModel = new DeleteModel(db)
        {
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        var result = await pageModel.OnGetAsync(null);
        Assert.IsType<NotFoundResult>(result);

        var result1 = await pageModel.OnGetAsync(1);
        Assert.IsType<NotFoundResult>(result1);

        var result2 = await pageModel.OnGetAsync(truck.ID);
        Assert.IsType<PageResult>(result2);
    }

    [Fact]
    public async Task OnPostAsyncTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();
        var truck = AddTruckOnDatabase(db);

        var pageModel = new DeleteModel(db)
        {
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        var result = await pageModel.OnPostAsync(null);
        Assert.IsType<NotFoundResult>(result);

        var result1 = await pageModel.OnPostAsync(1);
        Assert.IsType<RedirectToPageResult>(result1);

        var result2 = await pageModel.OnPostAsync(truck.ID);
        Assert.IsType<RedirectToPageResult>(result2);

        var truckDeleted = db.Truck.FirstOrDefault(t => t.ID == truck.ID);
        Assert.Null(truckDeleted);
    }
}