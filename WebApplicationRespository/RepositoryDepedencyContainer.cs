using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationRepository.Concreate;
using WebApplicationRepository.Interface;
using WebApplicationRespository.Concreate;
using WebApplicationRespository.Interface;

namespace WebApplicationRepository
{
    public class RepositoryDepedencyContainer
    {

        public static void Registration(IServiceCollection serviceCollectiopn)
        {


            serviceCollectiopn.AddScoped<IStateRepository, StateRepository>();
            serviceCollectiopn.AddScoped<IUserRepository, UserRepository>();
            serviceCollectiopn.AddScoped<IRoalMasterRepository, RoalMasterRepository>();

        }
    }
}
