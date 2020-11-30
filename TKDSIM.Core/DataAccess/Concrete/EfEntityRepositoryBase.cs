using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TKDSIM.Core.DataAccess.Interface;

namespace TKDSIM.Core.DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEfEntityRepositoryBase<TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return  entity;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return  filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
