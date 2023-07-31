using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.TGetAll();
            return View(students);
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            _studentService.TAdd(s);
            return RedirectToAction("Index", "Student");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentService.TGetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
           _studentService.TUpdate(s);
            return RedirectToAction("Index", "Student");
        }

      
        public IActionResult Delete(int id)
        {
            var student= _studentService.TGetById(id);
            if (student!=null)
            {
                _studentService.TDelete(student);
            }
            
            return RedirectToAction("Index", "Student");
        }
    }
}
