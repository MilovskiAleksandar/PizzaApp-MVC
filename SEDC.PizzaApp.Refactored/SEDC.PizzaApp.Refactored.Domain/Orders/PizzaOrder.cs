using SEDC.PizzaApp.Refactored.Domain.Enums;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Domain.Orders
{
    public class PizzaOrder : BaseEntity
    {
        public int PizzaId { get; set; }
        //we should always add apropiate propert(object) for the related record
        public Pizza Pizza { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int NumberOfPizzas { get; set; }

        public PizzaSize PizzaSize { get; set; }
    }
}
