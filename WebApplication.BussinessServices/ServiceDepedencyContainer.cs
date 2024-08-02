using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationBussinessServices.Concreate;
using WebApplicationBussinessServices.Interface;

namespace WebApplicationBussinessServices
{
    public class ServiceDepedencyContainer
    {
        public static void Registration(IServiceCollection serviceCollectiopn)
        {

            serviceCollectiopn.AddScoped<IStateService, StateService>();
            serviceCollectiopn.AddScoped<IUserService, UserService>();
            serviceCollectiopn.AddScoped<IRoalMasterService, RoalMasterService>();
        }
    }
}
