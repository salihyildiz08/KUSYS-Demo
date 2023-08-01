using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.ViewComponents.StudentCourse
{
    public class AddSCCourseList : ViewComponent
    {
        private readonly ICourseService _service;

        public AddSCCourseList(ICourseService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var values = _service.TGetAll();
            return View(values);
        }
    }
}
