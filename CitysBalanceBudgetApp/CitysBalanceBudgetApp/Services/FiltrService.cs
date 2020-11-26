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
                for (int i = 0; i < cities.Count(); i++)
                {
                    City Value = cities.ElementAt(i);
                    // проверяем все города и ищем соседей
                    if (Value.Point.X == city.Point.X + 1 && (Value.Point.Y != city.Point.Y + 1 || Value.Point.Y != city.Point.Y - 1)) 
                    {
                        // если сосед не содержит этот i то доболяем соседа в очередь
                        if (!Value.neighbors.Contains(i)) 
                        {
                            a.Enqueue(Value);
                        }
                        // добавляем в соседи этот город
                        city.neighbors.Append(i);

                    }
                    if (Value.Point.X == city.Point.X - 1 && (Value.Point.Y != city.Point.Y + 1 || Value.Point.Y != city.Point.Y - 1))
                    {
                        if (!Value.neighbors.Contains(i)) 
                        {
                            a.Enqueue(Value);
                        }
                        city.neighbors.Append(i);
                    }
                    if (Value.Point.Y == city.Point.Y - 1 && (Value.Point.X != city.Point.X + 1 || Value.Point.X != city.Point.Y - 1))
                    {
                        if (!Value.neighbors.Contains(i))
                        {
                            a.Enqueue(Value);
                        }
                        city.neighbors.Append(i);
                    }
                    if (Value.Point.Y == city.Point.Y + 1 && (Value.Point.X != city.Point.X + 1 || Value.Point.X != city.Point.X - 1))
                    {
                        if (!Value.neighbors.Contains(i))
                        {
                            a.Enqueue(Value);
                        }
                        city.neighbors.Append(i);
                    }
                }
                
            }
            return cities;
        }

        public IEnumerable<City> Filter(FiltrData filtrData)
        {
            IEnumerable<City> cities = filtrData.Cities;
            for (int i = 0; i < filtrData.Options.Iterations; i++) 
            { 
                // отнимаем бюджет который надо отнять
                foreach (City city in filtrData.Cities) 
                {
                    city.BudgetForNeighbors = city.Budget / filtrData.Options.PercentBet;
                    city.Budget -= city.BudgetForNeighbors * city.neighbors.Count();
                }
                foreach (City city in filtrData.Cities) 
                { 
                    foreach(int index in city.neighbors) 
                    {
                        // добавляем бюджет от соседей
                        city.Budget += cities.ElementAt(index).BudgetForNeighbors;
                    }
                }
            }
            return cities;
        }
    }
}
