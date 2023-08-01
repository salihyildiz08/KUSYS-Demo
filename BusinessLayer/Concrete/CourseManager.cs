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
    public class CourseManager : GenericService<Course>, ICourseService
    {
        public CourseManager(IRepositoryDal<Course> dal) : base(dal)
        {
        }
    }
}
