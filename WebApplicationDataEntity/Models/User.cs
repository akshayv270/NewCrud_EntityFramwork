using System;
using System.Collections.Generic;

namespace WebApplicationDataEntity.Models
{
    public partial class User
    {
        public int User1Id { get; set; }
        public string? EmailId { get; set; }
        public string? Passwords { get; set; }
        public string? PasswordSolt { get; set; }
        public string? Username { get; set; }
        public string? PhoneNo { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual RoleMaster? Role { get; set; }
    }
}
