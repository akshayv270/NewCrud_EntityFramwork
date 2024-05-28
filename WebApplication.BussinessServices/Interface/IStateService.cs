using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplocationBussinessEntity;

namespace WebApplicationBussinessServices.Interface
{
    public interface IStateService
    {
        List<StateViewModel> GetState();
        StateViewModel GetState(int id);



        bool AddEditState(StateViewModel user);

        bool DeleteState(int id);
    }
}
