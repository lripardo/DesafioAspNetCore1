using System;
using DesafioAspNetCore1.Models;
using Xunit;

namespace DesafioAspNetCore1.Tests;

public class TruckTest
{
    [Fact]
    public void CurrentYearTest()
    {
        var currentYearValidator = new CurrentYear();
        var validYear = DateTime.Now.Year;
        var invalidYears = new[] {validYear - 1, validYear + 1};

        Assert.True(currentYearValidator.IsValid(validYear));

        foreach (var year in invalidYears)
        {
            Assert.False(currentYearValidator.IsValid(year));
        }
    }

    [Fact]
    public void CurrentYearOrSubsequentTest()
    {
        var currentYearOrSubsequentValidator = new CurrentYearOrSubsequent();
        var validYears = new[] {DateTime.Now.Year, DateTime.Now.Year + 1};
        var invalidYears = new[] {validYears[0] - 1, validYears[1] + 1};

        foreach (var year in validYears)
        {
            Assert.True(currentYearOrSubsequentValidator.IsValid(year));
        }

        foreach (var year in invalidYears)
        {
            Assert.False(currentYearOrSubsequentValidator.IsValid(year));
        }
    }

    [Fact]
    public void ModelAllowedTest()
    {
        var modelAllowedValidator = new ModelAllowed();
        var validModels = new[] {"FM", "FH"};
        var invalidModels = new[] {"", "Other", "M", "MyModel", null};

        foreach (var year in validModels)
        {
            Assert.True(modelAllowedValidator.IsValid(year));
        }

        foreach (var year in invalidModels)
        {
            Assert.False(modelAllowedValidator.IsValid(year));
        }
    }
}