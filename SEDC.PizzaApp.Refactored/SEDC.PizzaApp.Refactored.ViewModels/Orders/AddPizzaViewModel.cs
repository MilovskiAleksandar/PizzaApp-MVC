using SEDC.PizzaApp.Refactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.ViewModels.Orders
{
    public class AddPizzaViewModel
    {
        [Display(Name = "Pizza")]
        public int PizzaId { get; set; }
        [Display(Name = "Size")]
        public PizzaSize PizzaSize { get; set; }
        [Display(Name = "Number of pizzas")]
        public int NumberOfPizzas { get; set; }

        public int OrderId { get; set; }
    }
}
