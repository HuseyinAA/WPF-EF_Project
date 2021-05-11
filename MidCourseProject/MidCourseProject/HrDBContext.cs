using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MidCourseProject
{
    public partial class HrDBContext : DbContext
    {
        public HrDBContext()
        {
        }

        public HrDBContext(DbContextOptions<HrDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeClock> EmployeeClocks { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HrDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.HrRate)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("hrRate");

                entity.Property(e => e.IsWorking)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("isWorking");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("postCode");
            });

            modelBuilder.Entity<EmployeeClock>(entity =>
            {
                entity.Property(e => e.EmployeeClockId).HasColumnName("employeeClockID");

                entity.Property(e => e.ClockDate)
                    .HasColumnType("datetime")
                    .HasColumnName("clockDate");

                entity.Property(e => e.ClockIn)
                    .HasColumnType("datetime")
                    .HasColumnName("clockIn");

                entity.Property(e => e.ClockOut)
                    .HasColumnType("datetime")
                    .HasColumnName("clockOut");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.TotalPay)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("totalPay");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeClocks)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeC__emplo__300424B4");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("Employer");

                entity.Property(e => e.EmployerId).HasColumnName("employerID");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employers)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Employer__employ__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
