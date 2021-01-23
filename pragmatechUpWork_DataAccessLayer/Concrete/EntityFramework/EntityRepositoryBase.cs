using pragmatechUpWork_Entities;
using pragmatechUpWork_GeneralLayer.DataAccessLayer.Abstract;
using pragmatechUpWork_GeneralLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework
{
    public class EntityRepositoryBase<T> : IEntityRepository<T>
        where T : class, IEntity, new()
    {
        private UpWorkContext context;

        public EntityRepositoryBase(UpWorkContext upWorkContext)
        {
            context = upWorkContext;
        }

        public async Task<bool> Create(T entity)
        {
            try
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<T> Get(Expression<Func<T, bool>> expression = null)
        {
            return context.Set<T>().SingleOrDefaultAsync(expression);
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression==null ? context.Set<T>().ToListAsync() : context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                var modifiedEntity = context.Entry(entity);
                modifiedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string mesaj = ex.Message;
                return false;
            }
        }
    }
}
