using System;
using System.Collections.Generic;

namespace Assignment14_Part1.Models
{
    public partial class Student
    {
        public int StudentUniqueId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public int CourseId { get; set; }
        public string FeeStatus { get; set; } = null!;
        public int CourseYear { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
