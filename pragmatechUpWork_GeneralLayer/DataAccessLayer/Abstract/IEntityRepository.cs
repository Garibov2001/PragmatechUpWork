using pragmatechUpWork_GeneralLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_GeneralLayer.DataAccessLayer.Abstract
{
    public interface IEntityRepository<T>
        where T:class,IEntity,new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null);
        Task<T> Get(Expression<Func<T, bool>> expression = null);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

    }
}
