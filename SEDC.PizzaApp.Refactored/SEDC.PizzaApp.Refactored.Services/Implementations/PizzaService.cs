
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.Mappers.Pizzas;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            //_pizzaRepository = new PizzaRepository();
            _pizzaRepository = pizzaRepository;
        }
        public List<PizzaDropDownViewModel> GetAllPizzasForDropDown()
        {
            //get all pizzas from db
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();
            //map to view models
            List<PizzaDropDownViewModel> pizzaDropDownViewModels = pizzasDb.Select(x => x.ToPizzaDropDownViewModel()).ToList(); 
            //return
            return pizzaDropDownViewModels;
        }

        public List<string> GetPizzasOnPromotion()
        {
            //1. get pizzas on promotion from db
            List<Pizza> pizaOnPromotion = _pizzaRepository.GetPizzasOnPromotion();

            //2.get the names of the pizzas
            return pizaOnPromotion.Select(x => x.Name).ToList();
        }

        
    }
}
