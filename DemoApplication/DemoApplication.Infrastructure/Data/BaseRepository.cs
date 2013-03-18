#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Infrastructure.Data
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Common.Paging;
    using Core.Interfaces.Data;
    using Core.Interfaces.Paging;
    using Core.Model;

    #endregion

    /// <summary>
    /// An abstract baseclass handling basic CRUD operations against the context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : DomainObject
    {        
        protected readonly IDbSet<T> _dbset;
        protected readonly IDatabaseFactory _databaseFactory;
        private IDataContext _context;

        protected BaseRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;            
            _dbset = DataContext.DbSet<T>();
        }

		public virtual IQueryable<T> Query
        {
            get { return _dbset; }
        }

        public IDataContext DataContext
        {
            get { return _context ?? (_context = _databaseFactory.Get()); }
        }

        protected string EntitySetName { get; set; }

        public virtual void SaveOrUpdate(T entity)
        {
            if (UnitOfWork.IsPersistent(entity))
            {
                DataContext.Entry(entity).State = EntityState.Modified;
            }
            else
                _dbset.Add(entity);
        }

        public virtual T GetById(object id)
        {
            return _dbset.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Query;
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return Query.AsNoTracking();
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void BulkDelete(List<object> keys)
        {
            keys.ForEach(i => Delete(GetById(i)));
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression, int maxHits = 100)
        {
            return Query.Where(expression).Take(maxHits);
        }

        public IPage<T> Page(int page = 1, int pageSize = 10)
        {
            var internalPage = page - 1;
            var data = Query.OrderByDescending(k => k.Created).Skip(pageSize * internalPage).Take(pageSize).AsEnumerable();
            return new Page<T>(data, _dbset.Count(), pageSize, page);
        }

        public long Count()
        {
            return _dbset.LongCount();
        }

        public long Count(Expression<Func<T, bool>> expression)
        {
            return expression != null ? _dbset.Where(expression).LongCount() : Count();
        }

        public void Dispose()
        {
            DataContext.ObjectContext().Dispose();
        }
    }
}