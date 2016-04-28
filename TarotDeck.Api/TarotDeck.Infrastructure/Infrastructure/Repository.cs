using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TarotDeck.Infrastructure.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDatabaseFactory DatabaseFactory { get; set; }

        private TarotDeckDataContext _dataContext;
        protected TarotDeckDataContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = DatabaseFactory.GetDataContext());
            }
        }

        protected IDbSet<TEntity> DbSet { get; set; }

        public Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;

            DbSet = DataContext.Set<TEntity>();
        }

        // CREATE
        public TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        // READ
        public bool Any(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbSet.Any(whereExpression);
        }
        public int Count()
        {
            return DbSet.Count();
        }
        public int Count(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbSet.Count(whereExpression);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }
        public TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbSet.FirstOrDefault(whereExpression);
        }
        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbSet.Where(whereExpression);
        }

        // UPDATE
        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        // DELETE
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
