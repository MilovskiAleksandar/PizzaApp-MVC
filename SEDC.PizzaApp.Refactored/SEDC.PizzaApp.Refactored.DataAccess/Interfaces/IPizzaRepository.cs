using SEDC.PizzaApp.Refactored.Domain.Pizzas;


namespace SEDC.PizzaApp.Refactored.DataAccess.Interfaces
{
    //this inteface now has all signatures from IRepository + List<Pizza> GetPizzasOnPromotion();
    public interface IPizzaRepository : IRepository<Pizza>
    {
        List<Pizza> GetPizzasOnPromotion();
    }
}
