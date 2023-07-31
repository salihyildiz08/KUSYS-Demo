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
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void TAdd(Student entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Student entity)
        {
            throw new NotImplementedException();
        }

        public List<Student> TGetAll()
        {
            return _studentDal.GetAll();
        }

        public Student TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}

