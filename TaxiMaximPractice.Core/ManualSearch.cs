using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPractice.Core;

public class ManualSearch : INearestDriverSearch
{
    public List<Driver> FindNearestDrivers(
        List<Driver> drivers,
        int orderX,
        int orderY,
        int count)
    {
        var sorted = drivers.ToList();

        sorted.Sort((a, b) =>
        {
            double distA = Distance(a.X, a.Y, orderX, orderY);
            double distB = Distance(b.X, b.Y, orderX, orderY);

            return distA.CompareTo(distB);
        });

        return sorted.Take(count).ToList();
    }

    private double Distance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(
            Math.Pow(x2 - x1, 2) +
            Math.Pow(y2 - y1, 2));
    }
}
