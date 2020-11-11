using CitysBalanceBudgetApp.Interfaces;
using CitysBalanceBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace CitysBalanceBudgetApp.Controllers
{
    public class CitiesController
    {
        private readonly IValidator _validator;
        private readonly IFilterService _service;
        public CitiesController(IValidator validator, IFilterService service)
        {
            _validator = validator;
            _service = service;
        }
        public IEnumerable<City> FiltrData(FiltrData filtrData) 
        {
            if (!_validator.IsValid(filtrData))
                throw new Exception("данные не валидны");
            /*
            if (!_validator.DifName(filtrData))
                throw new Exception("данные не валидны");
            */
            filtrData.Cities = _service.SherchNewNeighbors(filtrData.Cities);
            IEnumerable<City> result = _service.Filter(filtrData);
            return result;

        }
    }
}
