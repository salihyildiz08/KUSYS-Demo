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
    public class EfStudentDal : IStudentDal
    {
        private readonly ApplicationDbContext _context;

        public EfStudentDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
