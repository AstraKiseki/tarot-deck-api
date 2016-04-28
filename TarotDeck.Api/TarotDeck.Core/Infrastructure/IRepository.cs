using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TarotDeck.Core.Infrastructure
{
    public interface IRepository<TEntity>
    {
        // CREATE
        TEntity Add(TEntity entity);

        // READ
        TEntity GetById(object id);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> whereExpression);
        int Count();
        int Count(Expression<Func<TEntity, bool>> whereExpression);
        bool Any(Expression<Func<TEntity, bool>> whereExpression);

        // UPDATE
        void Update(TEntity entity);

        // DELETE
        void Delete(TEntity entity);
    }
}
