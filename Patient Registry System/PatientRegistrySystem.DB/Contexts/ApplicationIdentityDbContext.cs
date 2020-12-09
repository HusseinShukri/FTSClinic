using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Models.IdentityModels;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                b.HasMany(e => e.Record)
                .WithOne(e => e.ApplicationUser).OnDelete(DeleteBehavior.NoAction);

                b.HasMany(e => e.Employee)
                .WithOne(e => e.ApplicationUser).OnDelete(DeleteBehavior.NoAction);

                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Doctor>(b =>
            {
                b.Property(e => e.DoctorId)
                .ValueGeneratedOnAdd();

                b.HasMany(a => a.Record)
                .WithOne(u => u.Doctor).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Employee>(b =>
            {
                b.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd();

                b.HasOne(e => e.ApplicationUser)
                .WithMany(u => u.Employee).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Record>(b =>
            {
                b.Property(e => e.RecordId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Prescription>(b =>
            {
                b.Property(e => e.PrescriptionId)
                .ValueGeneratedOnAdd();

                b.HasMany(a => a.Record)
                .WithOne(p => p.Prescription).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Medicine>(b =>
            {
                b.Property(e => e.MedicineId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Company>(b =>
            {
                b.Property(e => e.CompanyId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0CVKC97;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog = PatientRegistrySystem");
        }
    }
}
