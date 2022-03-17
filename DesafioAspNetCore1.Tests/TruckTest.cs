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
        var invalidYears = new int[] {validYear - 1, validYear + 1};

        Assert.True(currentYearValidator.IsValid(validYear));

        foreach (var year in invalidYears)
        {
            Assert.False(currentYearValidator.IsValid(year));
        }
    }
}