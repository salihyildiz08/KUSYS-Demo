using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseService _service;

        public StudentCourseController(IStudentCourseService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var studentCourses = _service.GetAllWithStudentCourse();
            return View(studentCourses);
        }


        [HttpPost]
        public IActionResult Create(StudentCourse c)
        {
            _service.TAdd(c);
            return RedirectToAction("Index", "StudentCourse");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _service.TGetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(StudentCourse c)
        {
            _service.TUpdate(c);
            return RedirectToAction("Index", "StudentCourse");
        }


        public IActionResult Delete(int id)
        {
            var studentCourse = _service.TGetById(id);
            if (studentCourse != null)
            {
                _service.TDelete(studentCourse);
            }

            return RedirectToAction("Index", "StudentCourse");
        }


    }
}
