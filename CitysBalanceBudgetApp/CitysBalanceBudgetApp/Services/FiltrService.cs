using CitysBalanceBudgetApp.Interfaces;
using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitysBalanceBudgetApp.Services
{
    public class FiltrService : IFilterService
    {
        public City[] Filter(FiltrData filtrData)
        {
            
            City[] cities = filtrData.Cities.ToArray();
            double[] minMaxBuget = new double[2] {0 , filtrData.Cities.ToArray()[0].Budget};
            int[] minMaxName = new int[2] { 0, 0 };

            for (int i = 0; i < filtrData.Options.Iterations; i++) 
            {
                double oneIterBet = 0;
                for ( int index = 0; index < cities.Length; index++) 
                { 
                    if (cities[index].Budget < minMaxBuget[1]) 
                    {
                        minMaxBuget[1] = cities[index].Budget;
                        minMaxName[1] = index;
                    }
                    if (cities[index].Budget > minMaxBuget[0])
                    {
                        minMaxBuget[0] = cities[index].Budget;
                        minMaxName[0] = index;
                    }
                    cities[index].Budget = cities[index].Budget -(cities[index].Budget * filtrData.Options.PercentBet);
                    oneIterBet = oneIterBet + cities[index].Budget * filtrData.Options.PercentBet;

                }
                oneIterBet = oneIterBet / cities.Length;
                cities[minMaxName[0]].Budget = cities[minMaxName[0]].Budget - cities[minMaxName[0]].Budget * filtrData.Options.PercentReach;
                cities[minMaxName[1]].Budget = cities[minMaxName[1]].Budget + cities[minMaxName[1]].Budget * filtrData.Options.PercentReach;
                foreach (City city in cities) 
                {
                    city.Budget = city.Budget + oneIterBet;
                }
            }
            return cities;
        }
    }
}
