using System;
using System.Collections.Generic;

namespace WebApplicationDataEntity
{
    public partial class Employee
    {
        public Employee()
        {
            EmergencyContacts = new HashSet<EmergencyContact>();
        }

        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? HireDate { get; set; }
        public int? DepartmentId { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public int? AddressId { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; }
    }
}
