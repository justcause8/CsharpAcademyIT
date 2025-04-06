using Laba2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Laba2
{
    public partial class AppContext : DbContext
    {
        public AppContext() { }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Настройка подключения к базе данных SQLite
                optionsBuilder.UseLazyLoadingProxies()
                              .UseSqlite("Data Source=D:\\ПОЛИТЕХ\\Академия IT\\3 курс 5 семестр\\.Net\\CsharpAcademyIT\\Laba2\\Laba2.db");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи для Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Настройка связи "многие-ко-многим" между Teacher и Course
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithMany(c => c.Teachers)
                .UsingEntity(j => j.ToTable("TeacherCourses"));
        }

        /*public void SeedData()
        {
            if (!Students.Any() && !Courses.Any())
            {
                Student s1 = new Student { FirstName = "Vasya", LastName = "Pupkin", Age = 20, Address = "Moskow" };
                Student s2 = new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 25, Address = "Bratsk" };
                Student s3 = new Student { FirstName = "Petr", LastName = "Petrov", Age = 35, Address = "Irkutsk" };

                Students.Add(s1);
                Students.Add(s2);

                Course course1 = new Course { CourseName = "Математика" };
                Course course2 = new Course { CourseName = "Физика" };

                Courses.Add(course1);
                Courses.Add(course2);

                SaveChanges();
            }
        
        }*/
    }
}