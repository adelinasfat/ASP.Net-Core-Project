using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Students
{
    public class EditModel : ClassroomsPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
            .Include(b => b.Teacher)
            .Include(b => b.Classrooms).ThenInclude(b => b.Class)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }

            PopulateAssignedClass(_context, Student);

            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "ID", "TeacherName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedClasses)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Student
            .Include(i => i.Teacher)
            .Include(i => i.Classrooms)
            .ThenInclude(i => i.Class)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
            studentToUpdate,
            "Student",
            i => i.Surname, i => i.Name,
            i => i.Address, i => i.Phone, i => i.EnrollmentDate, i => i.Teacher))
            {
                UpdateClassrooms(_context, selectedClasses, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        
            UpdateClassrooms(_context, selectedClasses, studentToUpdate);
            PopulateAssignedClass(_context, studentToUpdate);
            return Page();
        }
    }

}
