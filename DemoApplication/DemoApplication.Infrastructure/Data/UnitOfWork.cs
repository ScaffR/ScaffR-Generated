#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Data
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Core.Interfaces.Data;
    using Core.Model;

    #endregion

    public partial class UnitOfWork : IUnitOfWork
    {        
        private readonly IDatabaseFactory _databaseFactory;
        private IDataContext _datacontext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
            this.DataContext.ObjectContext().SavingChanges += (sender, e) => BeforeSave(this.GetChangedOrNewEntities());
        }

        public IDataContext DataContext
        {
            get { return this._datacontext ?? (this._datacontext = this._databaseFactory.Get()); }
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
            return entity.Id != 0;
        }

        public int Commit()
        {
            return this.DataContext.ObjectContext().SaveChanges();
        }
    }
}
