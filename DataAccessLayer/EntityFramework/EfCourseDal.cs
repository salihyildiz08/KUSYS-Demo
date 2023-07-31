using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCourseDal : GenericRepository<Course>
    {
        public EfCourseDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
