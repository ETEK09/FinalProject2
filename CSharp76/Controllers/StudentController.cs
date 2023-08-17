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

        public IActionResult UpdateStudent(int id)
        {
            Student stdnt = repo.GetStudent(id);


            if (stdnt == null)
            {
                return View("StudentNotFound");
            }
            return View(stdnt);
        }



    }

}
