using System.Threading.Tasks;
using DesafioAspNetCore1.Pages.Trucks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xunit;

namespace DesafioAspNetCore1.Tests;

public class TruckDetailsPageTest : TruckPageTest
{
    [Fact]
    public async Task OnGetAsyncTest()
    {
        var db = new RazorPagesTruckContext(Options);
        var mockPageRequest = new MockPageRequest();
        var truck = AddTruckOnDatabase(db);

        var pageModel = new DetailsModel(db)
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
}