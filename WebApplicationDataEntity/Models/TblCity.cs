using System;
using System.Collections.Generic;

namespace WebApplicationDataEntity.Models
{
    public partial class TblCity
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string? CityName { get; set; }
        public bool? Isactive { get; set; }

        public virtual TblState? State { get; set; }
    }
}
