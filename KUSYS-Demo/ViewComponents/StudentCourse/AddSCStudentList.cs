using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.ViewComponents.StudentCourse
{
    public class AddSCStudentList : ViewComponent
    {
        private readonly IStudentService _service;

        public AddSCStudentList(IStudentService service)
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
