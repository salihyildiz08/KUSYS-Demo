using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentCourseManager : GenericService<StudentCourse>, IStudentCourseService
    {
        private readonly IStudentCourseDal _studentCourseDal;

        public StudentCourseManager(IRepositoryDal<StudentCourse> dal, IStudentCourseDal studentCourseDal) : base(dal)
        {
            _studentCourseDal = studentCourseDal;
        }

        public List<StudentCourse> GetAllWithStudentCourse()
        {
            return _studentCourseDal.GetAllWithStudentCourse();
        }
    }
}
