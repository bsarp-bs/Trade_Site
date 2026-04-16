using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Infrastructure_Persistence.Context;

namespace Trade_Site_Infrastructure_Persistence.Repository
{
    public class GenericRepository<S> : IGenericInterface<S> where S : class
    {
        private readonly DemandContext _demandContext;

        public GenericRepository(DemandContext demandContext)
        {
            _demandContext = demandContext;
        }

        public async Task AddAsync(S entity)
        {
            _demandContext.Set<S>().Add(entity);
            await _demandContext.SaveChangesAsync();
        }
            
        public async Task DeleteAsync(S entity)
        {
            _demandContext.Set<S>().Remove(entity);
            await _demandContext.SaveChangesAsync();
        }

        public async Task<List<S>> GetAsync()
        {
            var value = await _demandContext.Set<S>().ToListAsync();
            return value;
        }

        public async Task<S> GetByIdAsync(int id)
        {
            var value = await _demandContext.Set<S>().FindAsync(id);
            return value;
        }

        public async Task<S> GetFilterAsync(Expression<Func<S, bool>> filter)
        {
            var value = await _demandContext.Set<S>().SingleOrDefaultAsync(filter);
            return value;
        }

        public async Task UpdateAsync(S entity)
        {
            _demandContext.Set<S>().Update(entity);
            await _demandContext.SaveChangesAsync();
        }
    }
}
