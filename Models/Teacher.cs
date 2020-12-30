using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        [Display(Name = "Teacher Name")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Teacher name must be of type: 'Name Surname'"), Required, StringLength(50, MinimumLength = 3)]

        public string TeacherName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
