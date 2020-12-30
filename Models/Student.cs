using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Enroll Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
    }
}
