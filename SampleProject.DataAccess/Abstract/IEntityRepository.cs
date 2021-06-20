using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SampleProject.Entities.Abstract;

namespace SampleProject.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> queryFilter = null);
        T Get(Expression<Func<T, bool>> queryFilter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
