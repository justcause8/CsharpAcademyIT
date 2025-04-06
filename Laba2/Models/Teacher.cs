using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // Связь многие-ко-многим с Course
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
