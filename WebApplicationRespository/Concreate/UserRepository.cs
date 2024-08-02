using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDataEntity;
using WebApplicationRepository.Interface;

namespace WebApplicationRepository.Concreate
{
    public class UserRepository : IUserRepository
    {
        private readonly Employee_ManagmentContext context;
        public UserRepository(Employee_ManagmentContext employee_ManagmentContext)
        {
            context = employee_ManagmentContext;
        }
        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
    }
}
