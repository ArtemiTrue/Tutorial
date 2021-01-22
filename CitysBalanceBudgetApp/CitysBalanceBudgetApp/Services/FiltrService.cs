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
        public IEnumerable<City> SherchNeighbor(IEnumerable<City> cities)
        {
            Queue<int> a = new Queue<int>();
            a.Enqueue(0);
            while (a.Count > 0)
            {
                int IndexOfThis = a.Dequeue();
                for (int i = 0; i < cities.Count(); i++)
                {
                    City value = cities.ElementAt(i);
                    // проверяем все города и ищем соседей
                    if (Point.Add(value.Point, new Size(1, 0)) == cities.ElementAt(IndexOfThis).Point ||
                        Point.Add(value.Point, new Size(-1, 0)) == cities.ElementAt(IndexOfThis).Point ||
                        Point.Add(value.Point, new Size(0, 1)) == cities.ElementAt(IndexOfThis).Point ||
                        Point.Add(value.Point, new Size(0, -1)) == cities.ElementAt(IndexOfThis).Point)
                    {
                        // если сосед не содержит этот i то доболяем соседа в очередь
                        //if (value.neighbors.Count() == 0) // !value.neighbors.Contains(i))
                        //{
                        //    a.Enqueue(IndexOfElement(cities, value));
                        //}
                        // добавляем в соседи этот город
                        a.Enqueue(IndexOfElement(cities, value));
                        cities.ElementAt(IndexOfThis).neighbors.Append(i);
                    }
                }
            }
            return cities;
        }
        public IEnumerable<City> Filter(FiltrData filtrData) 
        {
            IEnumerable<City> cities = SherchNeighbor(filtrData.Cities);
            double[] BudgetForNeighbors = new double[cities.Count()];
            for (int i = 0; i < filtrData.Options.Iterations; i++)
            {
                // отнимаем бюджет который надо отнять
                for (int count = 0; count < cities.Count(); count++)
                {
                    BudgetForNeighbors[count] = cities.ElementAt(count).Budget / filtrData.Options.PercentBet;
                    cities.ElementAt(count).Budget -= BudgetForNeighbors[count] * cities.ElementAt(count).neighbors.Count();
                }
                cities = GiveBudget(cities, BudgetForNeighbors);
            }
            return cities;
        } 
        private IEnumerable<City> TakeBudget(IEnumerable<City> cities, double[] BudgetForNeighbors,double percentBet) 
        {
            for (int count = 0; count < cities.Count(); count++)
            {
                BudgetForNeighbors[count] = cities.ElementAt(count).Budget / percentBet;
                cities.ElementAt(count).Budget -= BudgetForNeighbors[count] * cities.ElementAt(count).neighbors.Count();
            }
            return cities;
        }
        private IEnumerable<City> GiveBudget(IEnumerable<City> cities, double[] BudgetForNeighbors) 
        {
            for (int count = 0; count < cities.Count(); count++)
            {
                foreach (int index in cities.ElementAt(count).neighbors)
                {
                    cities.ElementAt(count).Budget += BudgetForNeighbors[count];
                }
            }
            return cities;
        }
        public int IndexOfElement(IEnumerable<City> cities, City value) 
        {
            for (int i = 0; i < cities.Count(); i++) 
            {
                if (cities.ElementAt(i) == value) 
                {
                    return i;
                }
            }
            return 1;
        }
    }
}
