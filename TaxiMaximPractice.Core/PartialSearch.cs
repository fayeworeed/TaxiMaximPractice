using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPractice.Core;

public class PartialSearch : INearestDriverSearch
{
    public List<Driver> FindNearestDrivers(
        List<Driver> drivers,
        int orderX,
        int orderY,
        int count)
    {
        var result = new List<Driver>();
        var used = new HashSet<int>();

        for (int i = 0; i < count; i++)
        {
            Driver? nearest = null;
            double minDistance = double.MaxValue;

            foreach (var driver in drivers)
            {
                if (used.Contains(driver.Id))
                    continue;

                double distance = Distance(
                    driver.X,
                    driver.Y,
                    orderX,
                    orderY);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = driver;
                }
            }

            if (nearest != null)
            {
                result.Add(nearest);
                used.Add(nearest.Id);
            }
        }

        return result;
    }

    private double Distance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(
            Math.Pow(x2 - x1, 2) +
            Math.Pow(y2 - y1, 2));
    }
}
