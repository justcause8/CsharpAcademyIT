using Microsoft.EntityFrameworkCore;

namespace CsharpAcademyIT.Lab3
{
    public partial class AppContext1 : DbContext
    {
        public AppContext1() { }

        public AppContext1(DbContextOptions<AppContext1> options)
            : base(options)
        {
            Database.EnsureCreated(); // Создает базу данных, если она не существует
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=D:\\ПОЛИТЕХ\\Академия IT\\3 курс 5 семестр\\.Net\\CsharpAcademyIT\\CsharpAcademyIT\\Lab3\\Lab3.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Age)
                    .IsRequired();

                entity.Property(e => e.Address)
                    .HasMaxLength(200);
            });
        }
    }
}