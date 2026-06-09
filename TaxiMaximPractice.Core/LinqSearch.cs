using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPractice.Core;

public class LinqSearch : INearestDriverSearch
{
    public List<Driver> FindNearestDrivers(
        List<Driver> drivers,
        int orderX,
        int orderY,
        int count)
    {
        return drivers
            .OrderBy(d =>
                Distance(d.X, d.Y, orderX, orderY))
            .Take(count)
            .ToList();
    }

    private double Distance(
        int x1,
        int y1,
        int x2,
        int y2)
    {
        return Math.Sqrt(
            Math.Pow(x2 - x1, 2) +
            Math.Pow(y2 - y1, 2));
    }
}
