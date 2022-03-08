using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_13.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string? CourseName { get; set; }
        [Required]
        public int CourseDuration { get; set; }
        [Required]
        public int Fees { get; set; }

        [Required]
        public string DegreeType { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
