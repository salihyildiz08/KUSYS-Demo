using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfStudentCourseDal : GenericRepository<StudentCourse>,IStudentCourseDal
    {
        private readonly ApplicationDbContext _context;
        public EfStudentCourseDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<StudentCourse> GetAllWithStudentCourse()
        {
            return _context.StudentCourses.Include(s => s.Student).Include(c => c.Course).ToList();
        }
    }
}
