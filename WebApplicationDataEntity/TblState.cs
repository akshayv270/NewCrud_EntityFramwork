using System;
using System.Collections.Generic;

namespace WebApplicationDataEntity
{
    public partial class TblState
    {
        public TblState()
        {
            TblCities = new HashSet<TblCity>();
        }

        public int Id { get; set; }
        public string? StateName { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<TblCity> TblCities { get; set; }
    }
}
