using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDataEntity;

namespace WebApplicationRespository.Interface
{
    public interface IStateRepository
    {
        List<TblState> GetStates();

        TblState GetState(int id);

    }
}
