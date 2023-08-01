using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepositoryDal<T> _dal;

        public GenericService(IRepositoryDal<T> dal)
        {
            _dal = dal;
        }

        public void TAdd(T entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(T entity)
        {
            _dal.Delete(entity);
        }

        public List<T> TGetAll()
        {
            return _dal.GetAll();
        }

        public T TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public void TUpdate(T entity)
        {
            _dal.Update(entity);
        }
    }
}
