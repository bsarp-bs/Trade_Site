using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Trade_Site_Demand_Application.Interface
{
    public interface IGenericInterface<T> where T : class
    {
        Task<List<T>> GetAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetFilterAsync(Expression<Func<T, bool>> filter);
    }
}
