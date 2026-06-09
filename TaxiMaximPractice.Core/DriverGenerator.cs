using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPractice.Core;

public static class DriverGenerator
{
    public static List<Driver> Generate(
        int count,
        int maxX,
        int maxY)
    {
        var random = new Random();

        var drivers = new List<Driver>();

        for (int i = 0; i < count; i++)
        {
            drivers.Add(new Driver(
                i,
                random.Next(maxX),
                random.Next(maxY)));
        }

        return drivers;
    }
}
