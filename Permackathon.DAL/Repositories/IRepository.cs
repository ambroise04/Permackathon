using System.Collections.Generic;

namespace Permackathon.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        public T Insert(T entity);
        public T Update(T entity);
        public bool Delete(int Id);
        public T Get(int id);
        public ICollection<T> GetAll();
    }
}