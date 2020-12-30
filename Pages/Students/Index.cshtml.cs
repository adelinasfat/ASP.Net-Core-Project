using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
        public StudentData StudentD { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }

        public async Task OnGetAsync(int? id, int? classID)
        {
            StudentD = new StudentData();

            StudentD.Students = await _context.Student
            .Include(b => b.Teacher)
            .Include(b => b.Classrooms)
            .ThenInclude(b => b.Class)
            .AsNoTracking()
            .OrderBy(b => b.Surname)
            .ToListAsync();
            if (id != null)
            {
                StudentID = id.Value;
                Student student = StudentD.Students
                .Where(i => i.ID == id.Value).Single();
                StudentD.Classes = student.Classrooms.Select(s => s.Class);
            }
        }
    }
}
