using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentManager : GenericService<Student>, IStudentService
    {
        public StudentManager(IRepositoryDal<Student> dal) : base(dal)
        {
        }
    }
}

