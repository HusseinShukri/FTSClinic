using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Seeds;

namespace PatientRegistrySystem.DB.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationIdentityDbContext()
        {
        }
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Record> Record { get; set; }


        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluintApi

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Record>()
                .Property(e => e.RecordId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Prescription>()
                .Property(e => e.PrescriptionId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Medicine>()
                .Property(e => e.MedicineId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.ApplicationUser)
                        .WithMany(u => u.Employee).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                .HasMany(a => a.Record)
                .WithOne(u => u.Doctor).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescription>()
                .HasMany(a => a.Record)
                .WithOne(p => p.Prescription).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Employee)
                .WithOne(e => e.ApplicationUser).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Record)
                .WithOne(e => e.ApplicationUser).OnDelete(DeleteBehavior.NoAction);

            #endregion
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0CVKC97;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog = PatientRegistrySystem");
        }
    }
}
