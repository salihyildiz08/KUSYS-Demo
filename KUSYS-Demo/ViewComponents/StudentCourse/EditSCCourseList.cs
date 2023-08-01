using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KUSYS_Demo.ViewComponents.StudentCourse
{
    public class EditSCCourseList : ViewComponent
    {
        private readonly ICourseService _service;
        private readonly IStudentCourseService _studentService;

        public EditSCCourseList(ICourseService service, IStudentCourseService studentService)
        {
            _service = service;
            _studentService = studentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var studentCourses = _studentService.GetAllWithStudentCourse().Where(x => x.StudentId == id).Select(x => x.CourseId).ToList();
            var values = _service.TGetAll().Where(course => !studentCourses.Contains(course.CourseId)).ToList();

            return View(values);
        }
    }
}
