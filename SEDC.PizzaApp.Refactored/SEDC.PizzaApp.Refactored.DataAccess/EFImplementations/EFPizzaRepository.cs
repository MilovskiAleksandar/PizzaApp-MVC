using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.DataAccess.EFImplementations
{
    public class EFPizzaRepository : IPizzaRepository
    {
        private PizzaAppDbContext _dbContext;

        public EFPizzaRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            //we dont need joins with other tables , since we need only Id and Name (from Pizzas table)
            return _dbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
           return _dbContext.Pizzas.FirstOrDefault(p => p.Id == id);
        }
        public void Insert(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }

        //specific method only for pizzas
        public List<Pizza> GetPizzasOnPromotion()
        {
            return _dbContext.Pizzas.Where(x => x.IsOnPromotion).ToList();
        }
    }
}
