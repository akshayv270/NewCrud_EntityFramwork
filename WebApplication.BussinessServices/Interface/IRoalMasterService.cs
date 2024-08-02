using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplocationBussinessEntity;

namespace WebApplicationBussinessServices.Interface
{
    public interface IRoalMasterService
    {
        public List<RoalViewModel> GetRoals();
    }
}
