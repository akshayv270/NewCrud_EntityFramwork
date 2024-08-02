using System;
using System.Collections.Generic;

namespace WebApplicationDataEntity.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Address1 { get; set; }
    }
}
