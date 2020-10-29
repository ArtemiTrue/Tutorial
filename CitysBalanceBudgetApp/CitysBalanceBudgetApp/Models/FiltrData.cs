using System;
using System.Collections.Generic;
using System.Text;

namespace CitysBalanceBudgetApp.Models
{
    public class FiltrData
    {
        public IEnumerable<City> Cities { get; set; }
        public FiltrOptions Options { get; set; }
    }
}
