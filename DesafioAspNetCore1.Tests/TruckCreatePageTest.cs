using System;
using System.Linq;
using System.Threading.Tasks;
using DesafioAspNetCore1.Models;
using DesafioAspNetCore1.Pages.Trucks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xunit;

namespace DesafioAspNetCore1.Tests;

public class TruckCreatePageTest : TruckPageTest
{
    [Fact]
    public void OnGetTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var createModel = new CreateModel(db);

        var result = createModel.OnGet();

        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public async Task OnPostAsyncInvalidModelTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();

        var pageModel = new CreateModel(db)
        {
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        pageModel.ModelState.AddModelError("Message.Text", "The Text field is required.");

        var result = await pageModel.OnPostAsync();

        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public async Task OnPostAsyncValidModelTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();

        var currentYear = DateTime.Now.Year;
        var truck = new Truck(0, "FH", currentYear, currentYear);

        var pageModel = new CreateModel(db)
        {
            Truck = truck,
            PageContext = mockPageRequest.PageContext,
            TempData = mockPageRequest.TempData,
            Url = mockPageRequest.URL
        };

        var result = await pageModel.OnPostAsync();

        Assert.IsType<RedirectToPageResult>(result);

        var truckSaved = db.Truck.First();

        Assert.True(truckSaved.ID == truck.ID);
    }
}