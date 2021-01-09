using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Class
    {
        public int ID { get; set; }

        [Display(Name = "Class Name")]
        [RegularExpression(@"^[A-Z]\s\W\s[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Class name must be of type: 'Letter - Description'"), Required, StringLength(50, MinimumLength = 3)]
        public string ClassName { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
    }
}
