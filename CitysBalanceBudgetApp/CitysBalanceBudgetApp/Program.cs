using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CitysBalanceBudgetApp.Controllers;
using CitysBalanceBudgetApp.Models;
using CitysBalanceBudgetApp.Services;

namespace CitysBalanceBudgetApp
{
    class Program
    {
        static void Main(string[] args)
        {


            City Aa = new City();

            ValidatorService validatorService = new ValidatorService();
            FiltrService filtrService = new FiltrService();
            CitiesController citiesController = new CitiesController(validatorService,filtrService);
            FiltrData data = new FiltrData
            {
                Cities = new City[]
                {
                    new City { Budget = 1000, Name = "mmmm", Point = new Point { X = 1, Y = 1 }}
                },
                Options = new FiltrOptions
                {
                    Iterations = 100,
                    PercentBet = 0.06,
                    PercentReach = 0.03
                }
            };
            citiesController.FiltrData(data);

        }
    }
}