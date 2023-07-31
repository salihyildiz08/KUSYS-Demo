using BusinessLayer.Absract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentCourseManager : GenericManager<StudentCourse>, IStudentCourseService
    {
        public StudentCourseManager(GenericRepository<StudentCourse> repository) : base(repository)
        {
        }
    }
}
