#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Data
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using Core.Interfaces.Data;
    using Core.Model;

    #endregion

    public partial class UnitOfWork : IUnitOfWork
    {
        private IDataContext _datacontext;
        private readonly IDatabaseFactory _databaseFactory;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            this.DataContext.ObjectContext().SavingChanges += (sender, e) => BeforeSave(this.GetChangedOrNewEntities());
        }

        public IDataContext DataContext
        {
            get { return this._datacontext ?? (this._datacontext = _databaseFactory.Get()); }
        }

        private IEnumerable<DomainObject> GetChangedOrNewEntities()
        {
            const EntityState NewOrModified = EntityState.Added | EntityState.Modified;

            return this.DataContext.ObjectContext().ObjectStateManager.GetObjectStateEntries(NewOrModified)
                .Where(x => x.Entity != null).Select(x => x.Entity as DomainObject);
        }

        public void BeforeSave(IEnumerable<DomainObject> entities)
        {
            foreach (var entity in entities)
            {
                entity.Updated = DateTime.Now;
                entity.Created = !IsPersistent(entity) ? DateTime.Now : entity.Created;
            }
        }

        public static bool IsPersistent(DomainObject entity)
        {
            var keyAttributedProps = entity.GetType().GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length == 1);
            return (keyAttributedProps != null) && !keyAttributedProps.GetValue(entity, null).ToString().Equals("0");
        }

        public int Commit()
        {
            return this.DataContext.ObjectContext().SaveChanges();
        }
    }
}
