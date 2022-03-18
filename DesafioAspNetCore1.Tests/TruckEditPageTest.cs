using System.Linq;
using System.Threading.Tasks;
using DesafioAspNetCore1.Models;
using DesafioAspNetCore1.Pages.Trucks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xunit;

namespace DesafioAspNetCore1.Tests;

public class TruckEditPageTest : TruckPageTest
{
    [Fact]
    public async Task OnGetAsyncTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();
        var truck = AddTruckOnDatabase(db);

        var pageModel = new EditModel(db)
        {
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        var result = await pageModel.OnGetAsync(null);
        Assert.IsType<NotFoundResult>(result);

        var result2 = await pageModel.OnGetAsync(1);
        Assert.IsType<NotFoundResult>(result2);

        var result3 = await pageModel.OnGetAsync(truck.ID);
        Assert.IsType<PageResult>(result3);
    }

    [Fact]
    public async Task OnPostAsyncInvalidModelTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();

        var pageModel = new EditModel(db)
        {
            Truck = new Truck(1),
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        var result1 = await pageModel.OnPostAsync();
        Assert.IsType<NotFoundResult>(result1);

        pageModel.ModelState.AddModelError("Message.Text", "The Text field is required.");

        var result2 = await pageModel.OnPostAsync();
        Assert.IsType<PageResult>(result2);
    }

    [Fact]
    public async Task OnPostAsyncValidModelTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();
        var truck = AddTruckOnDatabase(db);

        var pageModel = new EditModel(db)
        {
            Truck = truck,
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        truck.Model = "FM";
        truck.ModelYear++;
        
        var result = await pageModel.OnPostAsync();
        Assert.IsType<RedirectToPageResult>(result);

        var editedTruck = db.Truck.FirstOrDefault(t => t.ID == truck.ID);
        Assert.NotNull(editedTruck);
        
        Assert.True(editedTruck.Model == truck.Model && editedTruck.ModelYear == truck.ModelYear);
    }
}