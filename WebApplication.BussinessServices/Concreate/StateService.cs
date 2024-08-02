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
using AutoMapper;
using WebApplicationDataEntity;

namespace WebApplicationBussinessServices.Concreate
{
    public  class StateService : IStateService
    {
        private readonly IStateRepository stateRepo;

        private readonly IMapper _mapper;

        public StateService(IStateRepository stateRepository, IMapper mapper)
        {
            stateRepo = stateRepository;
            _mapper = mapper;
        }

        public bool AddEditState(StateViewModel state)
        {
            var p = _mapper.Map<TblState>(state);
            return stateRepo.AddEditState(p);
        }

        public bool DeleteState(int id)
        {
            return stateRepo.DeleteState(id);
        }

        public StateViewModel GetState(int id)
        {
            var d = stateRepo.GetState(id);
           return _mapper.Map<StateViewModel>(d);
            // return d.ToViewModel();
        }


        public List<StateViewModel> GetState()
        {
            var d = stateRepo.GetState();
            return _mapper.Map<List<StateViewModel>>(d);
           //return d.ToViewModel();
        }
    }
}
