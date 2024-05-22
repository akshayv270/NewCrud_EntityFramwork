using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDataEntity;
using WebApplicationRespository.Interface;

namespace WebApplicationRespository.Concreate
{
    public class StateRepository : IStateRepository
    {
        private readonly Employee_ManagmentContext context;
        public StateRepository()



        {
            context = new Employee_ManagmentContext();
        }

        TblState IStateRepository.GetState(int id)
        {
            return context.TblStates.Find(id);  
        }

        List<TblState> IStateRepository.GetStates()
        {
            return context.TblStates.ToList();
        }
    }
}
