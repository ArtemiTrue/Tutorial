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
            Point[] AllCoordinates = new Point[filterData.Cities.Count()];
            if (filterData.Options.Iterations < 0) 
            {
                return false;
            }
            if (filterData.Options.PercentBet < 0) 
            {
                return false;
            }
                foreach (City i in filterData.Cities.ToArray()) 
            {
                if (i.Name == null) // (i.Point.IsEmpty)) 
                {
                    return false;
                }
                if (i.Budget < 0) 
                {
                    return false;
                }
                if (i.Point.X < 0 || i.Point.Y < 0) 
                {
                    return false;
                }
                if (AllCoordinates.Contains(i.Point)) 
                {
                    return false;
                }
            }
            
            return true;

        }
        
        //public bool DifName(FiltrData filterData) 
        //{
        //    bool val = true;
        //    string[] names = new string[filterData.Cities.ToArray().Length] 
        //    foreach (City city in filterData.Cities) 
        //    { 
        //        if (city.Name in names)   
               
        //    }
            
        // }
        
     }
};
