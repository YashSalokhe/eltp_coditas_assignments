using System;
using System.Collections.Generic;

#nullable disable

namespace _16_March.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public int Fees { get; set; }
        public string DegreeType { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
