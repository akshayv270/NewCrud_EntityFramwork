using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationBussinessServices.Interface;
using WebApplicationRespository.Interface;
using WebApplicationRespository.Concreate;
using WebApplocationBussinessEntity;
using WebApplicationCommon;

namespace WebApplicationBussinessServices.Concreate
{
    public  class StateService : IStateService
    {
        private readonly IStateRepository stateRepo;

        public StateService()
        {
            stateRepo = new StateRepository();
        }

        public bool AddEditState(StateViewModel user)
        {
            return stateRepo.AddEditState(user.ToDataEntity());
        }

        public bool DeleteState(int id)
        {
            return stateRepo.DeleteState(id);
        }

        public StateViewModel GetState(int id)
        {
            var d = stateRepo.GetState(id);
            return d.ToViewModel();
        }


        public List<StateViewModel> GetState()
        {
            var d = stateRepo.GetState();

           return d.ToViewModel();
        }
    }
}
