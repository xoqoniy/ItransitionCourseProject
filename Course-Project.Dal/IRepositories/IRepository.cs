using Course_Project.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Dal.IRepositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);

        TEntity Update(TEntity entity);
        IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        bool DeleteMany(Expression<Func<TEntity, bool>> expression);

        ValueTask SaveAsync();
    }

}
