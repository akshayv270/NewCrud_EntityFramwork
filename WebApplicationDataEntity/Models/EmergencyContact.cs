using System;
using System.Collections.Generic;

namespace WebApplicationDataEntity.Models
{
    public partial class EmergencyContact
    {
        public int ContactId { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
