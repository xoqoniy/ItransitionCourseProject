using Course_Project.Dal.IRepositories;
using Course_Project.Domain.Commons;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Course_Project.Dal.DbContexts;

namespace Course_Project.Dal.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;
        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }
        /// <summary>
        /// Deletes first item that matched expression and keep track of it until change saved
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>true if action is successful, false if unable to delete</returns>
        public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await this.SelectAsync(expression);

            if (entity is not null)
            {
                entity.IsDeleted = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes all elements if expression matches
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
        {
            var entities = dbSet.Where(expression);
            if (entities.Any())
            {
                foreach (var entity in entities)
                    entity.IsDeleted = true;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts element to a table and keep track of it until change saved
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = await this.dbSet.AddAsync(entity);

            return entry.Entity;
        }

        /// <summary>
        /// Saves tracking changes and write them to database permenantly
        /// </summary>
        /// <returns></returns>
        public async ValueTask SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Selects all elements from table that matches condition and include relations
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
        {
            IQueryable<TEntity> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

            if (includes is not null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        /// <summary>
        /// selects element from a table specified with expression and can includes relations
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        //public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        //    => await this.SelectAll(expression, includes).FirstOrDefaultAsync();


        public async Task<TEntity> SelectAsync(
        Expression<Func<TEntity, bool>> expression, string[] includes = null)
        => await this.SelectAll(expression, includes).FirstOrDefaultAsync();


        /// <summary>
        /// Updates entity and keep track of it until change saved
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entryentity = this.dbContext.Update(entity);

            return entryentity.Entity;
        }
    }
}
