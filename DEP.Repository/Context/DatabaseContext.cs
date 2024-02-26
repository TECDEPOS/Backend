using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DEP.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<FileTag> FileTags { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PersonCourse> PersonCourses { get; set; }


        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=192.168.20.33,1433; Initial Catalog=DEP; TrustServerCertificate=True; User ID=sa; Password=Passw0rd;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(x => new { x.CourseId });
            });

            modelBuilder.Entity<PersonCourse>(entity =>
            {
                entity.HasKey(x => new { x.CourseId, x.PersonId });
            });

            // Use .OnDelete(DeleteBehavior.SetNull) for the entities to set FK properties to null when deleting a FK record.
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasOne(x => x.EducationalConsultant)
                .WithMany(x => x.EducationalConsultantPersons)
                .HasForeignKey(x => x.EducationalConsultantId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.OperationCoordinator)
                .WithMany(x => x.OperationCoordinatorPersons)
                .HasForeignKey(x => x.OperationCoordinatorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Location)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.LocationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(x => x.Department)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(x => x.Location)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.LocationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(x => x.OperationCoordinatorPersons)
                .WithOne(x => x.OperationCoordinator)
                .HasForeignKey(x => x.OperationCoordinatorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(x => x.EducationalConsultantPersons)
                .WithOne(x => x.EducationalConsultant)
                .HasForeignKey(x => x.EducationalConsultantId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.EducationBoss)
                .WithMany(x => x.EducationLeaders)
                .HasForeignKey(x => x.EducationBossId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Models.File>()
            .HasOne(f => f.FileTag)
            .WithMany()
            .HasForeignKey(f => f.FileTagId)
            .OnDelete(DeleteBehavior.SetNull);

            var defaultPass = configuration.GetSection("UserSettings:DefaultPassword").Value;
            CreatePasswordHash(defaultPass, out byte[] passwordHash, out byte[] passwordSalt);

            // Creates a Super_Admin user when the DB is created through add-migration/update-database
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "Administrator",
                UserName = "admin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserRole = 0,
                PasswordExpiryDate = DateTime.Now.AddDays(-1),

            });
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
