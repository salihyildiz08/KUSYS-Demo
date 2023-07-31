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
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void TAdd(Course entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Course entity)
        {
            throw new NotImplementedException();
        }

        public List<Course> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Course TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
