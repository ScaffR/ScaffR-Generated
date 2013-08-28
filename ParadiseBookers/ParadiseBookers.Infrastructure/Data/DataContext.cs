#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Data.Entity;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Infrastructure.Data
{
    #region

    

    #endregion

    public partial class DataContext : BaseContext<DataContext>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Log> Log { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Beach> Beaches { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Attraction> Attractions { get; set; }

        public DbSet<LandingPage> LandingPages { get; set; }
    }    
}