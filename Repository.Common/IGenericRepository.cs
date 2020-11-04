using Common.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common.Experimenting1
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> FindAll(Func<T, bool> predicate);
        Task<T> GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
