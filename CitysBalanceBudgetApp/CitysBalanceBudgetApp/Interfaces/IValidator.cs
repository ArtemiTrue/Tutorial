using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitysBalanceBudgetApp.Interfaces
{
    public interface IValidator
    {
        bool IsValid(FiltrData fiterData);
        //bool DifName(FiltrData filtrData);
    }
}
