﻿using BusinessLayer.Absract;
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
    }
}
