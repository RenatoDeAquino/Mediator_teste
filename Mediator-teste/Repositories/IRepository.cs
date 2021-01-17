using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_teste.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T item);

        Task Edit(T item);

        Task Delete(int id);
    }
}
