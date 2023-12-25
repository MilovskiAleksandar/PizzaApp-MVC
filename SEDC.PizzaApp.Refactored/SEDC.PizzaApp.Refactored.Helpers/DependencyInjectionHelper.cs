using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.Refactored.DataAccess;
using SEDC.PizzaApp.Refactored.DataAccess.EFImplementations;

using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.Services.Implementations;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            //DEPENDENCY INJECTION
            //services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Order>, EFOrderRepository>();

            //services.AddTransient<IRepository<Pizza>, PizzaRepository>();
            //services.AddTransient<IRepository<Pizza>, EFPizzaRepository>();
            services.AddTransient<IPizzaRepository, EFPizzaRepository>();

            //services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<User>, EFUserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaService, PizzaService>();
        }
        public static void InjectDbContext(IServiceCollection services)
        {
            // Server=.\\SQLEXPRESS
            services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseSqlServer("Server=DESKTOP-AJQM08F;Database=PizzaAppDb;Trusted_Connection=True;TrustServerCertificate=true"));
        }
    }
}
