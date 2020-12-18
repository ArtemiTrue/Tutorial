using CitysBalanceBudgetApp.Interfaces;
using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CitysBalanceBudgetApp.Services
{
    public class FiltrService : IFilterService
    {
        public IEnumerable<City> Filter(FiltrData filtrData)
        {
            IEnumerable<City> cities = filtrData.Cities;
            Queue<int> a = new Queue<int>();
            a.Enqueue(0);
            while (a.Count > 0)
            {
                int IndexOfThis = a.Dequeue();
                for (int i = 0; i < cities.Count(); i++)
                {
                    City Value = cities.ElementAt(i);
                    // проверяем все города и ищем соседей
                    if (Point.Add(Value.Point, new Size(1, 0)) == cities.ElementAt(IndexOfThis).Point ||
                        Point.Add(Value.Point, new Size(-1, 0)) == cities.ElementAt(IndexOfThis).Point ||
                        Point.Add(Value.Point, new Size(0, 1)) == cities.ElementAt(IndexOfThis).Point ||
                        Point.Add(Value.Point, new Size(0, -1)) == cities.ElementAt(IndexOfThis).Point)
                    {
                        // если сосед не содержит этот i то доболяем соседа в очередь
                        if (!Value.neighbors.Contains(i))
                        {
                            a.Enqueue(cities.IndexOf(Value));
                        }
                        // добавляем в соседи этот город
                        cities.ElementAt(IndexOfThis).neighbors.Append(i);
                    }
                }

            }
            
            for (int i = 0; i < filtrData.Options.Iterations; i++) 
            { 
                // отнимаем бюджет который надо отнять
                foreach (City city in cities) 
                {
                    city.BudgetForNeighbors = city.Budget / filtrData.Options.PercentBet;
                    city.Budget -= city.BudgetForNeighbors * city.neighbors.Count();
                }
                foreach (City city in cities) 
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
