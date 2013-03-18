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

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Objects;
    using Core.Interfaces.Data;
    using Core.Model;

    #endregion

    public partial class DataContext : DbContext, IDataContext
    {
// ReSharper disable RedundantArgumentDefaultValue
        public DataContext() : this(true)
// ReSharper restore RedundantArgumentDefaultValue
        {
        }

        public DataContext(bool proxyCreation = true)            
        {
            this.Configuration.ProxyCreationEnabled = proxyCreation;
        }

        public ObjectContext ObjectContext()
        {
            return ((IObjectContextAdapter)this).ObjectContext;
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

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

    }    
}