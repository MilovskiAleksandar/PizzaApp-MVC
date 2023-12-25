
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.Mappers.Users;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            //_userRepository = new UserRepository();
            _userRepository = userRepository;
        }
        public List<UserDropDownViewModel> GetUsersForDropDown()
        {
            List<User> usersDb = _userRepository.GetAll();

            List<UserDropDownViewModel> userDropDownViewModels = usersDb.Select(x => UserMapper.ToUserDropDownViewModel(x)).ToList();
            return userDropDownViewModels;

        }
    }
}
