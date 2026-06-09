using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPractice.Core;

public interface INearestDriverSearch
{
    List<Driver> FindNearestDrivers(
        List<Driver> drivers,
        int orderX,
        int orderY,
        int count);
}
