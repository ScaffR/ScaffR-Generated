#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
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
    /// An abstract base class handling basic CRUD operations against the context.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public abstract class BaseRepository<TEntity, TContext> : IDisposable, IRepository<TEntity> 
        where TEntity : DomainObject 
        where TContext : IDataContext, new()
    {        
        protected readonly IDbSet<TEntity> _dbset;
        private IDataContext _context;

        protected BaseRepository()
        {         
            _dbset = DataContext.DbSet<TEntity>();
        }

		public virtual IQueryable<TEntity> Query
        {
            get { return _dbset; }
        }

        public IDataContext DataContext
        {
            get { return _context ?? (_context = new TContext()); }
        }

        protected string EntitySetName { get; set; }

        public virtual void SaveOrUpdate(TEntity entity)
        {
            if (UnitOfWork.IsPersistent(entity))
            {
                DataContext.Entry(entity).State = EntityState.Modified;
            }
            else
                _dbset.Add(entity);
        }

        public virtual TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Query;
        }

        public virtual IQueryable<TEntity> GetAllReadOnly()
        {
            return Query.AsNoTracking();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void BulkDelete(List<object> keys)
        {
            keys.ForEach(i => Delete(GetById(i)));
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int maxHits = 100)
        {
            return Query.Where(expression).Take(maxHits);
        }

        public IPage<TEntity> Page(int page = 1, int pageSize = 10)
        {
            var internalPage = page - 1;
            var data = Query.OrderByDescending(k => k.Created).Skip(pageSize * internalPage).Take(pageSize).AsEnumerable();
            return new Page<TEntity>(data, _dbset.Count(), pageSize, page);
        }

        public long Count()
        {
            return _dbset.LongCount();
        }

        public long Count(Expression<Func<TEntity, bool>> expression)
        {
            return expression != null ? _dbset.Where(expression).LongCount() : Count();
        }

        public void Dispose()
        {
            DataContext.ObjectContext().Dispose();
        }
    }
}