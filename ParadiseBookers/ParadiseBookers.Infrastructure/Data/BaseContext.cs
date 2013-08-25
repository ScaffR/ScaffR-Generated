#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using ParadiseBookers.Core.Interfaces.Data;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Infrastructure.Data
{
    #region

    

    #endregion

    public class BaseContext<TContext> : DbContext , IDataContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        } 
        protected BaseContext() : base("name=DataContext")
        {
            this.Configuration.ProxyCreationEnabled = true;
        }

        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }

        public virtual IDbSet<T> DbSet<T>() where T : DomainObject
        {
            return Set<T>();
        }

        public new DbEntityEntry Entry<T>(T entity) where T : DomainObject
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
