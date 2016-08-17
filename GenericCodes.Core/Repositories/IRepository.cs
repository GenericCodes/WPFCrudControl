using GenericCodes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCodes.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Find(params object[] keyValues);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Queryable();
       
    }
}
