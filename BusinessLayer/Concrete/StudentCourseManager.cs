using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class StudentCourseManager : IStudentCourseService
    {
        private readonly IStudentCourseDal _studentCourseDal;

        public StudentCourseManager(IStudentCourseDal studentCourseDal)
        {
            _studentCourseDal = studentCourseDal;
        }

        public List<StudentCourse> GetAllWithStudentCourse()
        {
            return _studentCourseDal.GetAllWithStudentCourse();
        }

        public void TAdd(StudentCourse entity)
        {
            _studentCourseDal.Add(entity);  
        }

        public void TDelete(StudentCourse entity)
        {
            _studentCourseDal.Delete(entity);
        }

        public List<StudentCourse> TGetAll()
        {
            return _studentCourseDal.GetAll().ToList();
        }

        public StudentCourse TGetById(int id)
        {
           return _studentCourseDal.GetById(id);
        }

        public void TUpdate(StudentCourse entity)
        {
            _studentCourseDal.Update(entity);
        }
    }
}
