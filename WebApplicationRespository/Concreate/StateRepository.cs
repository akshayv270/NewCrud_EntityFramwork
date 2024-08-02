using Microsoft.EntityFrameworkCore;
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
        public StateRepository(Employee_ManagmentContext employee_ManagmentContext)
        {
            context = employee_ManagmentContext;
        }
       // private readonly Employee_ManagmentContext context;
       /*
       //without using dependency injection
        public StateRepository()
        {
            context = new Employee_ManagmentContext();
        }
       */
      
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
            try
            {
                // Retrieve the state and its related cities
                var state = context.TblStates.Include(s => s.TblCities)
                                             .FirstOrDefault(s => s.Id == id);

                if (state == null)
                {
                    return false;
                }

                // Mark related cities as deleted
                foreach (var city in state.TblCities)
                {
                    city.Isactive = false;
                   // city.DeletedAt = DateTime.UtcNow;
                    context.TblCities.Update(city); // Update the city to apply soft delete
                }

                // Mark the state as deleted
                state.Isactive = false;
                //state.DeletedAt = DateTime.UtcNow;
                context.TblStates.Update(state); // Update the state to apply soft delete

                // Save changes to the context
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the state: {ex.Message}");
                return false;
            }

            /*
            try
            {
              
                var state = context.TblStates.Include(s => s.TblCities).FirstOrDefault(s => s.Id == id);
                if (state == null)
                {
                    return false;
                }

                
                context.TblCities.RemoveRange(state.TblCities);

               
                context.TblStates.Remove(state);

               
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the state: {ex.Message}");
                return false;
            }
            /*
            var d = context.TblStates.Find(id);
            context.TblStates.Remove(d);
            return context.SaveChanges() > 0 ? true : false;
            */
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
