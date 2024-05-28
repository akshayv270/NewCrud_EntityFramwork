using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDataEntity;
using WebApplocationBussinessEntity;

namespace WebApplicationCommon
{
   static public class Helper
    {
        public static StateViewModel ToViewModel(this TblState state)
        {
            return new StateViewModel
            {
                StateName = state.StateName,
                Id = state.Id,
                IsActive = state.Isactive?? false

            };

        }

        public static List<StateViewModel> ToViewModel(this List<TblState> states)
        {

            return states.Select(x => ToViewModel(x)).ToList();
        }

        public static TblState ToDataEntity(this StateViewModel user)
        {
            TblState state = new TblState();

            state.Id = user.Id;
            state.StateName = user.StateName;
            state.Isactive = user.IsActive;


            return state;
        }

    }
}
