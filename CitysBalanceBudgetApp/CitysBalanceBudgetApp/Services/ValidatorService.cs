using CitysBalanceBudgetApp.Interfaces;
using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Drawing;

namespace CitysBalanceBudgetApp.Services
{
    public class ValidatorService: IValidator
    {
        public bool IsValid(FiltrData filterData)
        {
            Point[] allCoordinates = new Point[filterData.Cities.Count()];
            foreach (City i in filterData.Cities.ToArray()) 
            { 
                if (IsNameValid(i) && IsBudgetValid(i) && IsPointValid(i, allCoordinates)) { return false; }
                allCoordinates.Append(i.Point);
            }
            return IsOptionsValid(filterData);
        }
        private bool IsNameValid(City city)
        {
            return string.IsNullOrEmpty(city.Name);
        }
        private bool IsBudgetValid(City city)
        {
            return (city.Budget < 0);
        }
        private bool IsPointValid(City city,Point[] allCoordinates) 
        { 
            return (city.Point.X < 0 && city.Point.Y < 0 && allCoordinates.Contains(city.Point));
        }
        private bool IsOptionsValid(FiltrData data) 
        {
            return (data.Options.Iterations > 0 || data.Options.PercentBet > 0 || data.Options.PercentBet < 1);
        }
    }
};
//var testResult = filterData.Cities.Any(
//    city => string.IsNullOrEmpty(city.Name) 
//    || city.Budget < 0 
//    || city.Point.X < 0 
//    || city.Point.Y < 0 
//    || allCoordinates.Contains(city.Point));
//return !testResult;