using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_13.Models
{
    public class Student
    {
        [Key]
        public int StudentUniqueId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string? FeeStatus { get; set; }

        [Required]
        public int CourseYear { get; set; } //Foreign KEy

        public Course Course { get; set; } //referential integrity 1-1
    }
}
