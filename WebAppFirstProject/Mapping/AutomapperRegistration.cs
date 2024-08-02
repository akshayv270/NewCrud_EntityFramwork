using AutoMapper;
using WebApplicationDataEntity;
using WebApplocationBussinessEntity;

namespace WebAppFirstProject.Mapping
{
    public class AutomapperRegistration : Profile
    {
        public AutomapperRegistration()
        {
            CreateMap< StateViewModel, TblState>().ReverseMap();
            CreateMap< UserViewModel, User>().ReverseMap();
            CreateMap<RoalViewModel, RoleMaster>().ReverseMap();
        }
    }
}
