using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationBussinessServices.Interface;
using WebApplicationRepository.Interface;
using WebApplocationBussinessEntity;

namespace WebApplicationBussinessServices.Concreate
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;

        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            userRepo = userRepository;
            _mapper = mapper;
        }
        public List<UserViewModel> GetUser()
        {
            var d = userRepo.GetUsers();
            return _mapper.Map<List<UserViewModel>>(d);
        }
    }
}
