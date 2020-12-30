using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Students
{
    public class CreateModel : ClassroomsPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "ID", "TeacherName");

            var student = new Student();
            student.Classrooms = new List<Classroom>();
            PopulateAssignedClass(_context, student);

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedClasses)
        {
            var newStudent = new Student();
            if (selectedClasses != null)
            {
                newStudent.Classrooms = new List<Classroom>();
                foreach (var cat in selectedClasses)
                {
                    var catToAdd = new Classroom
                    {
                        ClassID = int.Parse(cat)
                    };
                    newStudent.Classrooms.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Student>(
            newStudent,
            "Student",
            i => i.Surname, i => i.Name,
            i => i.Address, i => i.Phone, i => i.EnrollmentDate, i => i.TeacherID))
            {
                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedClass(_context, newStudent);
            return Page();
        }

    }
}
