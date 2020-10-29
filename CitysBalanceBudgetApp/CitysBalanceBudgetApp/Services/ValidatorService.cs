using CitysBalanceBudgetApp.Interfaces;
using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CitysBalanceBudgetApp.Services
{
     public class ValidatorService: IValidator
    {
        public bool IsValid(FiltrData filterData)
        {
            bool val = true;
            foreach (City i in filterData.Cities.ToArray()) 
            {
                if (i.Name == null) // (i.Point.IsEmpty)) 
                {
                    val = false;
                }
                if (i.Budget < 0) 
                {
                    val = false;
                }
            }
            return val;
        }
        /*
        public bool DifName(FiltrData filterData) 
        {
            bool val = true;
            string[] names = new string[filterData.Cities.ToArray().Length] 
            foreach (City city in filterData.Cities) 
            { 
                if (city.Name in names)   
               
            }
            
         }
        */
     }
};
