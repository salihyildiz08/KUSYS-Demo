using BusinessLayer.Absract;
using KUSYS_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KUSYS_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public HomeController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var students = _studentService.TGetAll().Count();
            ViewBag.students=students;
            var courses = _courseService.TGetAll().Count();
            ViewBag.courses = courses;
            return View();
        }

      
    }
}