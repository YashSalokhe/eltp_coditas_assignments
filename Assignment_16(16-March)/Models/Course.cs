using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_16_16_March_.Models
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
