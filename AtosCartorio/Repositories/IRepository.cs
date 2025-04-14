using System;
using System.Collections.Generic;

namespace AtosCartorio.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(bool forceReload = false);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
