using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiPractice.Core;

namespace TaxiPractice.Tests;

public class SearchTests
{
    private List<Driver> drivers;

    [SetUp]
    public void Setup()
    {
        drivers = new List<Driver>
        {
            new Driver(1, 0, 0),
            new Driver(2, 1, 1),
            new Driver(3, 5, 5),
            new Driver(4, 10, 10),
            new Driver(5, 2, 2)
        };
    }

    [Test]
    public void LinqSearch_ReturnsNearestDrivers()
    {
        var search = new LinqSearch();

        var result = search.FindNearestDrivers(
            drivers,
            0,
            0,
            2);

        Assert.That(result.Count, Is.EqualTo(2));

        Assert.That(result[0].Id, Is.EqualTo(1));
    }

    [Test]
    public void ManualSearch_ReturnsNearestDrivers()
    {
        var search = new ManualSearch();

        var result = search.FindNearestDrivers(
            drivers,
            0,
            0,
            2);

        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Test]
    public void PartialSearch_ReturnsNearestDrivers()
    {
        var search = new PartialSearch();

        var result = search.FindNearestDrivers(
            drivers,
            0,
            0,
            2);

        Assert.That(result.Count, Is.EqualTo(2));
    }
}
