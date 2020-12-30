using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class StudentData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Classroom> Classrooms { get; set; }
    }
}
