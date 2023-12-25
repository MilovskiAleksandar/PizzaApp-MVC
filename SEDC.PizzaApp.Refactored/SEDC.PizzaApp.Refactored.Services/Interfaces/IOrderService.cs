using SEDC.PizzaApp.Refactored.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);

        void CreateOrder(CreateOrderViewModel model);

        void AddPizzaToOrder(AddPizzaViewModel model);
        void DeleteOrder(int id);
    }
}
