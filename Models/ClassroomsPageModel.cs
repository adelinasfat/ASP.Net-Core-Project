using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;

namespace Proiect.Models
{
    public class ClassroomsPageModel : PageModel
    {
        public List<AssignedClass> AssignedClassDataList;
        public void PopulateAssignedClass(ProiectContext context, Student student)
        {
            var allClasses = context.Class;
            var classrooms = new HashSet<int>(
            student.Classrooms.Select(c => c.StudentID));
            AssignedClassDataList = new List<AssignedClass>();
            foreach (var cat in allClasses)
            {
                AssignedClassDataList.Add(new AssignedClass
                {
                    ClassID = cat.ID,
                    Name = cat.ClassName,
                    Assigned = classrooms.Contains(cat.ID)
                });
            }
        }
        public void UpdateClassrooms(ProiectContext context, string[] selectedClasses, Student studentToUpdate)
        {
            if (selectedClasses == null)
            {
                studentToUpdate.Classrooms = new List<Classroom>();
                return;
            }
            var selectedClassesHS = new HashSet<string>(selectedClasses);
            var classrooms = new HashSet<int>
            (studentToUpdate.Classrooms.Select(c => c.Class.ID));
            foreach (var cat in context.Class)
            {
                if (selectedClassesHS.Contains(cat.ID.ToString()))
                {
                    if (!classrooms.Contains(cat.ID))
                    {
                        studentToUpdate.Classrooms.Add(
                        new Classroom
                        {
                            StudentID = studentToUpdate.ID,
                            ClassID = cat.ID
                        });
                    }
                }
                else
                {
                    if (classrooms.Contains(cat.ID))
                    {
                        Classroom courseToRemove
                        = studentToUpdate
                        .Classrooms
                        .SingleOrDefault(i => i.ClassID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
