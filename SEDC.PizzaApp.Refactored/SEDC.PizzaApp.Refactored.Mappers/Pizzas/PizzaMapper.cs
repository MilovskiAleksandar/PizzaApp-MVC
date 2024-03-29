﻿using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.ViewModels.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Mappers.Pizzas
{
    public static class PizzaMapper
    {
        public static PizzaDropDownViewModel ToPizzaDropDownViewModel(this Pizza pizza)
        {
            return new PizzaDropDownViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
            };
        }
    }
}
