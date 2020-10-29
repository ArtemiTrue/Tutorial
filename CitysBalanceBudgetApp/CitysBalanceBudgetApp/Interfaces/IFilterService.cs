using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitysBalanceBudgetApp.Interfaces
{
    public interface IFilterService
    {
        City[] Filter(FiltrData filtrData);
    }
}
