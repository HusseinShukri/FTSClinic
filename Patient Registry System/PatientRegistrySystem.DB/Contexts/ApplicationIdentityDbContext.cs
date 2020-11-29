using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Seeds;
using System.Linq;

namespace PatientRegistrySystem.DB.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext
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
        public DbSet<User> User { get; set; }


        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluintApi
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.User)
                .WithOne(u => u.ApplicationUser);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
               .Property(e => e.UserId)
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
                        .HasOne(e => e.User)
                        .WithMany(u => u.Employee).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                .HasMany(a => a.Record)
                .WithOne(u => u.Doctor).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescription>()
                .HasMany(a => a.Record)
                .WithOne(p => p.Prescription).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employee)
                .WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Record)
                .WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(a => a.ApplicationUser)
                .WithOne(a => a.User);

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
