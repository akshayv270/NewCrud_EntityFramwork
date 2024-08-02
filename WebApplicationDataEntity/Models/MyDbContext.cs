using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationDataEntity.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<RoleMaster> RoleMasters { get; set; } = null!;
        public virtual DbSet<TblCity> TblCities { get; set; } = null!;
        public virtual DbSet<TblState> TblStates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-59IEF9L;Database=Employee_Managment;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__Emergenc__024E7A86A55963FE");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.EmergencyContactName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emergency_contact_name");

                entity.Property(e => e.EmergencyContactPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emergency_contact_phone");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmergencyContacts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Emergency__emplo__6383C8BA");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(20)
                    .HasColumnName("marital_status");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .HasColumnName("position");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__role_mas__760965CC15C9F9C2");

                entity.ToTable("role_master");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.ToTable("tbl_City");

                entity.Property(e => e.CityName).HasMaxLength(100);

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblCities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_City_Id");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.ToTable("tbl_State");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.StateName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.User1Id)
                    .HasName("PK__users__0A8B3F02176D14CB");

                entity.ToTable("users");

                entity.Property(e => e.User1Id).HasColumnName("user1_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(200)
                    .HasColumnName("email_id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.PasswordSolt)
                    .HasMaxLength(500)
                    .HasColumnName("password_solt");

                entity.Property(e => e.Passwords)
                    .HasMaxLength(500)
                    .HasColumnName("passwords");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(12)
                    .HasColumnName("phone_no");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__users__role_id__71D1E811");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
