using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    interface IRepository<T>
    {
        T insert(T entity);
        T update(int id, T entity);
        void delete(int id);
        List<T> getAll();
        T getById(int id);

    }
}
