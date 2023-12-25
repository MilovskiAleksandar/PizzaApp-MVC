

using SEDC.PizzaApp.Refactored.Domain.Orders;

namespace SEDC.PizzaApp.Refactored.Domain.Users
{
    //all domain entitities have Id, that is why they inherit from BaseEntity
    public class User : BaseEntity
    {
        //these properties reflect columns from tables in DB
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? SSN { get; set; }

        //1 User - Many orders
        //Da gi povleceme narackite posebno za sekoj user
        public List<Order> Orders { get; set; }

    }
}
