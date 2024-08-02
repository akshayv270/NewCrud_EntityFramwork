using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDataEntity;

namespace WebApplicationRepository.Interface
{
    public interface IRoalMasterRepository
    {
        List<RoleMaster> GetRoals();
    }
}
