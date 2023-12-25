using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Orders;
using SEDC.PizzaApp.Refactored.Mappers.Orders;
using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.Shared.CustomExceptions;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;

namespace SEDC.PizzaApp.Refactored.Services.Implementations
{
    public class OrderService : IOrderService
    {
        //we need a method that:
        //read from DB --we need a class that directly comunicates with DB(REPOSITORY class)
        //map to viewmodels
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;
        private IPizzaRepository _pizzaRepository;

        //public OrderService()
        //{
        //    _orderRepository = new OrderRepository();
        //    _userRepository = new UserRepository();
        //    _pizzaRepository = new PizzaRepository();
        //}

        public OrderService(IRepository<Order> orderRepository, IPizzaRepository pizzaRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizzaToOrder(AddPizzaViewModel model)
        {
            //validation 
            if(model.NumberOfPizzas <= 0 || model.NumberOfPizzas > 30)
            {
                throw new Exception("Number of pizzas must be a positive number, lower than 30.");
            }
            Order orderDb = _orderRepository.GetById(model.OrderId);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"Order with id {model.OrderId} was not found");
            }
            Pizza pizzaDb = _pizzaRepository.GetById(model.PizzaId);
            if(pizzaDb == null)
            {
                throw new ResourceNotFoundException($"Pizza with id {model.PizzaId} was not found");
            }

            orderDb.PizzaOrders.Add(new PizzaOrder
            {
                OrderId = model.OrderId,
                Order = orderDb,
                PizzaId = model.PizzaId,
                Pizza = pizzaDb,
                PizzaSize = model.PizzaSize,
                NumberOfPizzas = model.NumberOfPizzas
            });

            //update
            _orderRepository.Update(orderDb);
                
            

        }

        public void CreateOrder(CreateOrderViewModel model)
        {
            //1. validation
            //check if user 
            User userDb = _userRepository.GetById(model.UserId);
            if (userDb == null)
            {
                throw new ResourceNotFoundException($"User with id {model.UserId} not found");
            }


            //2. map viewmodels to domain models model.UserId
            Order newOrder = model.ToOrder(userDb);
            //3. send to db
            _orderRepository.Insert(newOrder);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteById(id);
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            //from db we get list of domain models
            List<Order> ordersDb = _orderRepository.GetAll();
            
            // MAPP to viewmodels
            List<OrderListViewModel> orderListViewModels = ordersDb.Select(x => x.ToOrderListViewModel()).ToList();
            return orderListViewModels;
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            //1. try to find an order in db with this id
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"Order with id {id} was not found");
            }

            //2. mapp domain to viewmodel
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
            //3. return the viewmodel
            return orderDetailsViewModel;
        }

        
    }
}
