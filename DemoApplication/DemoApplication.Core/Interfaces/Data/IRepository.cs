namespace DemoApplication.Core.Interfaces.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Paging;

    /// <summary>
    /// The generic base interface for all repositories...
    /// Purpose:
    /// - Implement this on the repository... Regardless of datasource... Xml, MSSQL, MYSQL etc..
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllReadOnly();

        T GetById(object id);

        void SaveOrUpdate(T entity);

        void Delete(T entity);

        void BulkDelete(List<object> keys);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression, int maxHits = 100);

        IPage<T> Page(int page = 1, int pageSize = 10);

        long Count();

        long Count(Expression<Func<T, bool>> expression);
    }
}