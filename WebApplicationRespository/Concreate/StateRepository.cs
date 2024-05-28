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

        public bool AddEditState(TblState state)
        {

            if (state.Id > 0)
            {
                var d = context.TblStates.Find(state.Id);
                d.StateName = state.StateName;
                d.Isactive = state.Isactive;


            }
            else
            {
                context.TblStates.Add(state);
            }

            return context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteState(int id)
        {
            var d = context.TblStates.Find(id);
            context.TblStates.Remove(d);
            return context.SaveChanges() > 0 ? true : false;
        }



        TblState IStateRepository.GetState(int id)
        {
            return context.TblStates.Find(id);  
        }

        List<TblState> IStateRepository.GetState()
        {
            return context.TblStates.ToList();
        }
    }
}
