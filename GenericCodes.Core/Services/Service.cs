using GenericCodes.Core.Entities;
using GenericCodes.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCodes.Core.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        #region Private Fields
        private readonly IRepository<TEntity> _repository;
        #endregion Private Fields

        #region Constructor
        protected Service(IRepository<TEntity> repository) { _repository = repository; }
        #endregion Constructor

        public virtual TEntity Find(params object[] keyValues) { return _repository.Find(keyValues); }

        public virtual void Insert(TEntity entity) { _repository.Insert(entity); }

        public virtual void InsertRange(IEnumerable<TEntity> entities) { _repository.InsertRange(entities); }

        public virtual void Update(TEntity entity) { _repository.Update(entity); }

        public virtual void Delete(object id) { _repository.Delete(id); }

        public virtual void Delete(TEntity entity) { _repository.Delete(entity); }

        public IQueryable<TEntity> Queryable() { return _repository.Queryable(); }

        public IEnumerable<TEntity> List() { return _repository.List(); }

        public IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.List(predicate);
        }
    }
}
