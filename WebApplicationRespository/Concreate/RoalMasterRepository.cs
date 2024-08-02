using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDataEntity;
using WebApplicationRepository.Interface;

namespace WebApplicationRepository.Concreate
{
    public class RoalMasterRepository : IRoalMasterRepository
    {
        private readonly Employee_ManagmentContext context;
        public RoalMasterRepository(Employee_ManagmentContext employee_ManagmentContext)
        {
            context = employee_ManagmentContext;
        }
        public List<RoleMaster> GetRoals()
        {
            return context.RoleMasters.ToList();
        }
    }
}
