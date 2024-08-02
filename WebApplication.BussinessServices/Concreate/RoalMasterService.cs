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
    public class RoalMasterService : IRoalMasterService
    {
        private readonly IRoalMasterRepository roalMasterRepo;

        private readonly IMapper _mapper;

        public RoalMasterService(IRoalMasterRepository roalMasterService, IMapper mapper)
        {
            roalMasterRepo = roalMasterService;
            _mapper = mapper;
        }
        public List<RoalViewModel> GetRoals()
        {
            var d = roalMasterRepo.GetRoals();
            return _mapper.Map<List<RoalViewModel>>(d);
        }
    }
}
