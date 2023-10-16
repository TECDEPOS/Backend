using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<FileTag> FileTags { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonModule> PersonModules { get; set; }


        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=192.168.20.34,1433; Initial Catalog=DEP; TrustServerCertificate=True; User ID=sa; Password=Passw0rd;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonModule>(entity =>
            {
                entity.HasKey(x => new { x.PersonModuleId });
            });

            //modelBuilder.Entity<Models.File>(entity =>
            //{
            //    entity
            //    .HasOne(x => x.FileTag)
            //    .WithMany(x => x.Files)
            //    .HasForeignKey(x => x.FileTagId)
            //    .IsRequired(false);

            //    entity
            //    .HasOne(x=> x.Person)
            //    .WithMany(x => x.Files)
            //    .HasForeignKey(x => x.PersonId)
            //    .IsRequired(false);
            //});

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
            });
        }

    }
}
