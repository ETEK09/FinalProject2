using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CSharp38.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSharp38.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;

        public StudentController(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var students = repo.GetAllStudents();
            return View(students);
        }

        public IActionResult ViewStudent(int id)
        {
            var student = repo.GetStudent(id);
            return View(student);
        }

        public IActionResult UpdateStudent(int id)
        {
            Student student = repo.GetStudent(id);

            if (student == null)
            {
                return View("StudentNotFound");
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudentToDatabase(Student student)
        {
            repo.UpdateStudent(student);
            return RedirectToAction("ViewStudent", new { id = student.ID });
        }

        public IActionResult InsertStudent()
        {
          
            Student newStudent = new Student
            {
                StudentID = "",
                FirstName = "",
                LastName = "",
                GitHubID = "",
                Age = 20,
                Grade = 100,
            };

            return View(newStudent);
        }

     

        public IActionResult InsertStudentToDatabase(Student newStudent)
        {
            repo.InsertStudent(newStudent);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(Student student)
        {
            repo.DeleteStudent(student);
            return RedirectToAction("Index");
        }
    }
}
