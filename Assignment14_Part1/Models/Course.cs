using System;
using System.Collections.Generic;

namespace Assignment14_Part1.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int CourseDuration { get; set; }
        public int Fees { get; set; }
        public string DegreeType { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
