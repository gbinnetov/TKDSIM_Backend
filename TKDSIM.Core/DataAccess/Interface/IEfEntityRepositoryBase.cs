using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TKDSIM.Core.DataAccess.Interface
{
    public interface IEfEntityRepositoryBase<T> where T : class, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
