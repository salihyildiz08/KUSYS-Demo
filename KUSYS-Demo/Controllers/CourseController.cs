using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var courses = _courseService.TGetAll();
            return View(courses);
        }


        [HttpPost]
        public IActionResult Create(Course c)
        {
            _courseService.TAdd(c);
            return RedirectToAction("Index", "Course");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseService.TGetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course c)
        {
            _courseService.TUpdate(c);
            return RedirectToAction("Index", "Course");
        }


        public IActionResult Delete(int id)
        {
            var course = _courseService.TGetById(id);
            if (course != null)
            {
                _courseService.TDelete(course);
            }

            return RedirectToAction("Index", "Course");
        }
    }
}
