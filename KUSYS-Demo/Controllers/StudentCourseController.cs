using BusinessLayer.Absract;
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

        public IActionResult Index(int studentID)
        {
            
            return View();
        }


    }
}
