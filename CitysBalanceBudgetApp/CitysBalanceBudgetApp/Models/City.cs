using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CitysBalanceBudgetApp.Models
{
    public class City
    {
        public string Name { get; set; }
        public double Budget { get; set; }
        public Point Point { get; set; }
        public IEnumerable<int> neighbors { get; set; }
        public double BudgetForNeighbors { get; set; }
    }
}