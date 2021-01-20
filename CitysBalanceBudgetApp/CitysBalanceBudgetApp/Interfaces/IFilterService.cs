using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitysBalanceBudgetApp.Interfaces
{
    public interface IFilterService
    {
        IEnumerable<City> Filter(FiltrData filtrData);
        int IndexOfElement(IEnumerable<City> cities, City value);
    }
}
