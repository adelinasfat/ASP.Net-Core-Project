using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ProiectContext : DbContext
    {
        public ProiectContext (DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect.Models.Student> Student { get; set; }

        public DbSet<Proiect.Models.Teacher> Teacher { get; set; }

        public DbSet<Proiect.Models.Class> Class { get; set; }

        public DbSet<Proiect.Models.Classroom> Classroom { get; set; }
    }
}
