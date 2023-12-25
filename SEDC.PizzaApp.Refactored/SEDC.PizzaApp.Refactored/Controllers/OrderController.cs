using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Mappers.Pizzas;
using SEDC.PizzaApp.Refactored.Services.Implementations;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.Shared.CustomExceptions;
using SEDC.PizzaApp.Refactored.ViewModels.Error;
using SEDC.PizzaApp.Refactored.ViewModels.Orders;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IPizzaService _pizzaService;
        public OrderController(IOrderService orderService, IUserService userService, IPizzaService pizzaService)
        {
            //_orderService = new OrderService();
            _orderService = orderService;
            _userService = userService;
            _pizzaService = pizzaService;
        }
        //show all orders
        public IActionResult Index()
        {
            try
            {
                List<OrderListViewModel> orders = _orderService.GetAllOrders();
                return View(orders);
            }
            catch (Exception ex)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    Message =
                    ex.Message
                });
            }
        }

        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return View("GeneralError", new GeneralErrorViewModel { Message = "Invalid id value!" });
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
                return View(orderDetailsViewModel);
            }
            catch(Exception ex)
            {
                return View("GeneralError", new GeneralErrorViewModel { Message = 
                    ex.Message});
            }
        }

        public IActionResult CreateOrder()
        {
            //this method is the first step of Create, get a view with form in it
            CreateOrderViewModel createOrderViewModel = new CreateOrderViewModel();
            //get all users from db, mapped as dropdown viewmodels
            ViewBag.Users = _userService.GetUsersForDropDown();
            return View(createOrderViewModel);
        }
        [HttpPost]
        public IActionResult CreateOrderPost(CreateOrderViewModel model)
        {
            try
            {
                _orderService.CreateOrder(model);
                return RedirectToAction("Index");
            }
            catch(ResourceNotFoundException ex)
            {
                return View("ResourceNotFound");
            }
            catch (Exception ex)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    Message =
                    ex.Message
                });
            }
        }

        //here id, is the id from the order that we are adding pizzas for
        public IActionResult AddPizza(int id)
        {
            AddPizzaViewModel addPizzaViewModel = new AddPizzaViewModel();
            addPizzaViewModel.OrderId = id;

            //get all pizzas from db and send them for dropdown
            ViewBag.Pizzas = _pizzaService.GetAllPizzasForDropDown();
            return View(addPizzaViewModel);
        }
        [HttpPost]
        public IActionResult AddPizzaPost(AddPizzaViewModel model)
        {
            try
            {
                _orderService.AddPizzaToOrder(model);
                return RedirectToAction("Details", new { id = model.OrderId });
            }
            catch (ResourceNotFoundException ex)
            {
                return View("ResourceNotFound");
            }
            catch (Exception ex)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    Message =
                    ex.Message
                });
            }
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return View("GeneralError", new GeneralErrorViewModel { Message = "Invalid id value!" });
            }

            try
            {
                //we need order details
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
                return View(orderDetailsViewModel);
            }
            catch(ResourceNotFoundException ex)
            {
                return View("ResourceNotFound");
            }
            catch (Exception ex)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    Message =
                    ex.Message
                });
            }
        }

        //this method is GET by default, because it is called vie <a> tag, link
        public IActionResult ConfirmDelete(int id)
        {
            if (id == null)
            {
                return View("GeneralError", new GeneralErrorViewModel { Message = "Invalid id value!" });
            }

            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");

        }
    }
}
