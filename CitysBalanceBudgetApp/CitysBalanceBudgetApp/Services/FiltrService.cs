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
        public IEnumerable<City> SherchNewNeighbors(IEnumerable<City> cities) 
        {
            Queue<City> a = new Queue<City>();
            a.Enqueue(cities.ElementAt(0));
            while (a.Count>0)
            {
                City city = a.Dequeue();
                foreach (City i in cities)
                {
                    if (i.Point.X == city.Point.X + 1 && (i.Point.Y != city.Point.Y + 1 || i.Point.Y != city.Point.Y - 1)) 
                    {
                        //если список соседей не содержит имя города i то добовляем туда это имя
                        if (!city.neighbors.Contains(i.Name)) 
                        { 
                            city.neighbors.Append(i.Name);
                            a.Enqueue(i);
                        }

                    }
                    if (i.Point.X == city.Point.X - 1 && (i.Point.Y != city.Point.Y + 1 || i.Point.Y != city.Point.Y - 1))
                    {
                        if (!city.neighbors.Contains(i.Name))
                        {
                            city.neighbors.Append(i.Name);
                            a.Enqueue(i);
                        }
                    }
                    if (i.Point.Y == city.Point.Y - 1 && (i.Point.X != city.Point.X + 1 || i.Point.X != city.Point.Y - 1))
                    {
                        if (!city.neighbors.Contains(i.Name))
                        {
                            city.neighbors.Append(i.Name);
                            a.Enqueue(i);
                        }
                    }
                    if (i.Point.Y == city.Point.Y + 1 && (i.Point.X != city.Point.X + 1 || i.Point.X != city.Point.X - 1))
                    {
                        if (!city.neighbors.Contains(i.Name))
                        {
                            city.neighbors.Append(i.Name);
                            a.Enqueue(i);
                        }
                    }
                }
                return cities;
            }
        }
        public IEnumerable<City> Filter(FiltrData filtrData)
        {
            IEnumerable<City> cities = filtrData.Cities;
            for (int i = 0; i < filtrData.Options.Iterations; i++) 
            { 
                
            }
                //City[] cities = filtrData.Cities.ToArray();
                //double[] minMaxBuget = new double[2] {0 , cities[0].Budget};
                //int[] minMaxName = new int[2] { 0, 0 };

                //for (int i = 0; i < filtrData.Options.Iterations; i++) 
                //{
                //    // 
                //    double oneIterBet = 0;
                //    for ( int index = 0; index < cities.Length; index++) 
                //    { 

                //        if (cities[index].Budget < minMaxBuget[1]) 
                //        {
                //            minMaxBuget[1] = cities[index].Budget;
                //            minMaxName[1] = index;
                //        }
                //        if (cities[index].Budget > minMaxBuget[0])
                //        {
                //            minMaxBuget[0] = cities[index].Budget;
                //            minMaxName[0] = index;
                //        }
                //        cities[index].Budget = cities[index].Budget -(cities[index].Budget * filtrData.Options.PercentBet);
                //        oneIterBet = oneIterBet + cities[index].Budget * filtrData.Options.PercentBet;

                //    }
                //    oneIterBet = oneIterBet / cities.Length;
                //    cities[minMaxName[0]].Budget = cities[minMaxName[0]].Budget - cities[minMaxName[0]].Budget * filtrData.Options.PercentReach;
                //    cities[minMaxName[1]].Budget = cities[minMaxName[1]].Budget + cities[minMaxName[1]].Budget * filtrData.Options.PercentReach;
                //    foreach (City city in cities) 
                //    {
                //        city.Budget = city.Budget + oneIterBet;
                //    }
                //}
                return cities;
        }
    }
}
