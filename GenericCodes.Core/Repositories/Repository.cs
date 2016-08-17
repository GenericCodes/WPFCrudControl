using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GenericCodes.Core.DbContext;
using GenericCodes.Core.Entities;
using Microsoft.Practices.ServiceLocation;

namespace GenericCodes.Core.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbContext.Set<TEntity>().Find(keyValues);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
           var dbset= _dbContext.Set<TEntity>();
           var entry = _dbContext.Entry(entity);
           if (entry.State == EntityState.Detached)
               dbset.Attach(entity);
           dbset.Remove(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbContext.Set<TEntity>();
        }

      
    }
}
