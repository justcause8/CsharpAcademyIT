using System.ComponentModel.DataAnnotations;

namespace WebAPI_Laba3.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Grade>? Grades { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
