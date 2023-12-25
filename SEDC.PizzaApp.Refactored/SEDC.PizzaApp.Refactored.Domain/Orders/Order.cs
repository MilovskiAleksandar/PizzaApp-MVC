using SEDC.PizzaApp.Refactored.Domain.Enums;
using SEDC.PizzaApp.Refactored.Domain.Users;

namespace SEDC.PizzaApp.Refactored.Domain.Orders
{
    public class Order : BaseEntity
    {
        //FOREIGN KEY column from USER
        public int UserId { get; set; }
        public User User { get; set; }
        //column (int) IN DB for ENUM
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }

        public List<PizzaOrder> PizzaOrders { get; set; }

        public Order()
        {
            PizzaOrders = new List<PizzaOrder>();
        }
    }
}
