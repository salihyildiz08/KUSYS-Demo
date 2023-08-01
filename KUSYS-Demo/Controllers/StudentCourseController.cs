using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.courses = "1";
            return View();
        }


        [HttpPost]
        public IActionResult Create(int[] CourseId, int StudentId)
        {
            List<string> courses = new List<string>(); // Var olan kursları geri döndünrmek için 
            foreach (int courseId in CourseId)
            {

                var stCr = _service.GetAllWithStudentCourse().FirstOrDefault(x => x.StudentId == StudentId && x.CourseId == courseId);
                if (stCr == null)
                {
                    StudentCourse s = new StudentCourse();
                    s.StudentId = StudentId;
                    s.CourseId = courseId;
                    _service.TAdd(s);
                }
                else
                {

                    courses.Add(stCr.Course.CourseName);// Var olan kursları ekliyoruz. 
                }

            }

            ViewBag.courses = courses;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _service.TGetById(id);
            return View(course);
        }


        [HttpGet]
        public IActionResult EditStudentCourses(int StudentId)
        {
            var course = _service.GetAllWithStudentCourse().Where(x=>x.StudentId== StudentId).ToList();
            ViewBag.StudentID = StudentId;
            if (course!=null)
            {
                string firstName = course.FirstOrDefault().Student.FirstName;
                string lastName = course.FirstOrDefault().Student.LastName;
                ViewBag.Name = firstName + " " + lastName;
            }
           
           
            return View(course);
        }



        [HttpPost]
        public IActionResult Edit(int StudentId, int[] CourseId)
        {
            foreach (int courseId in CourseId)
            {
                    StudentCourse s = new StudentCourse();
                    s.StudentId = StudentId;
                    s.CourseId = courseId;
                    _service.TAdd(s);
            }
            return Redirect("/StudentCourse/EditStudentCourses?StudentId="+StudentId);
        }



        [HttpPost]
        public IActionResult Delete(int StudentId,int[] CourseId)
        {
            foreach (int id in CourseId)
            {
                var studentCourse = _service.TGetAll().FirstOrDefault(x=>x.StudentId==StudentId && x.CourseId==id);
                if (studentCourse != null)
                {
                    _service.TDelete(studentCourse);
                }
            }

            return Redirect("/StudentCourse/EditStudentCourses?StudentId=" + StudentId);
        }


    }
}
