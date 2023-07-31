using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IRepositoryDal<T> _repository;

        public GenericManager(IRepositoryDal<T> repository)
        {
            _repository = repository;
        }

        public void TAdd(T entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> TGetAll()
        {
            return _repository.GetAll();
        }

        public T TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
