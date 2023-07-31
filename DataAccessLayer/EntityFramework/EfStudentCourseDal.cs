using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfStudentCourseDal : GenericRepository<StudentCourse>,IStudentCourseDal
    {
        public EfStudentCourseDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
