#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ParadiseBookers.Core.Extensions;
using ParadiseBookers.Core.Interfaces.Data;
using ParadiseBookers.Core.Interfaces.Paging;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Interfaces.Validation;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Services
{
    #region

    

    #endregion

    /// <summary>
    /// Base for all services... If you need specific businesslogic
    /// override these methods in inherited classes and implement the logic there.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> : IService<T> where T : DomainObject
    {
        protected IRepository<T> Repository;

        protected IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return Repository.GetAllReadOnly();
        }

        public virtual T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public virtual IValidationContainer<T> SaveOrUpdate(T entity)
        {
            var validation = entity.GetValidationContainer();
            if (!validation.IsValid)
                return validation;

            Repository.SaveOrUpdate(entity);
            UnitOfWork.Commit();
            return validation;
        }

        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
            UnitOfWork.Commit();
        }

        public void BulkDelete(List<int> keys)
        {
            Repository.BulkDelete(keys);
            UnitOfWork.Commit();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression, int maxHits = 100)
        {
            return Repository.Find(expression, maxHits);
        }

        public IPage<T> Page(int page = 1, int pageSize = 10)
        {
            return Repository.Page(page, pageSize);
        }

        public long Count()
        {
            return Repository.Count();
        }

        public long Count(Expression<Func<T, bool>> expression)
        {
            return Repository.Count(expression);
        }
    }
}
