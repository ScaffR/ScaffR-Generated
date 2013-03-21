#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using Model;

    #endregion

    public interface IDataContext
    {
        ObjectContext ObjectContext();
        IDbSet<T> DbSet<T>() where T : DomainObject;
        DbEntityEntry Entry<T>(T entity) where T : DomainObject;
        void Dispose();
    }
}