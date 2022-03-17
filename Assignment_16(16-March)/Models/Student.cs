using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_16_16_March_.Models
{
    public partial class Student
    {
        public int StudentUniqueId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string FeeStatus { get; set; }
        public int CourseYear { get; set; }

        public virtual Course Course { get; set; }
    }
}
