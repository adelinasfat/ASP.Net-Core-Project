using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Classroom
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int ClassID { get; set; }
        public Class Class { get; set; }
    }
}
