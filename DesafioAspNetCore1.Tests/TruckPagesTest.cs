using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioAspNetCore1.Pages.Trucks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace DesafioAspNetCore1.Tests;

public class TruckPagesTest
{
    private readonly DbContextOptionsBuilder<RazorPagesTruckContext> _optionsBuilder;

    public TruckPagesTest()
    {
        _optionsBuilder = new DbContextOptionsBuilder<RazorPagesTruckContext>();
    }

    [Fact]
    public void OnGetTest()
    {
        var mock = new Mock<RazorPagesTruckContext>(_optionsBuilder.Options);
        var createModel = new CreateModel(mock.Object);

        var result = createModel.OnGet();

        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public async Task OnPostAsyncInvalidModelTest()
    {
        var mock = new Mock<RazorPagesTruckContext>(_optionsBuilder.Options);

        var httpContext = new DefaultHttpContext();
        var modelState = new ModelStateDictionary();
        var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
        var modelMetadataProvider = new EmptyModelMetadataProvider();
        var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        var pageContext = new PageContext(actionContext)
        {
            ViewData = viewData
        };
        var pageModel = new CreateModel(mock.Object)
        {
            PageContext = pageContext,
            TempData = tempData,
            Url = new UrlHelper(actionContext)
        };
        pageModel.ModelState.AddModelError("Message.Text", "The Text field is required.");

        var result = await pageModel.OnPostAsync();

        Assert.IsType<PageResult>(result);
    }
}