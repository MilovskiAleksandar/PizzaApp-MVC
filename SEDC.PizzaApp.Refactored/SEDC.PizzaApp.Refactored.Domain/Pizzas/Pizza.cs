using SEDC.PizzaApp.Refactored.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Domain.Pizzas
{
    public class Pizza : BaseEntity
    {
        //these properties reflect columns from tables in DB
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsOnPromotion { get; set; }

        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
