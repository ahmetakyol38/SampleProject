using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SampleProject.DataAccess.Abstract;
using SampleProject.Entities.Abstract;

namespace SampleProject.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> queryFilter = null)
        {
            using (TContext context = new TContext())
            {
                return queryFilter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(queryFilter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> queryFilter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(queryFilter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityAdded = context.Entry(entity);
                entityAdded.State = EntityState.Added;
                context.SaveChanges();

                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityUpdated = context.Entry(entity);
                entityUpdated.State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityDeleted = context.Entry(entity);
                entityDeleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
