﻿namespace DemoApplication.Infrastructure.Data
{
    using Core.Interfaces.Data;

    public partial class DatabaseFactory : IDatabaseFactory
    {
        private IDataContext _datacontext;

        public IDataContext Get()
        {
            return this._datacontext ?? (_datacontext = new DataContext());
        }

        public void Dispose()
        {
            // TODO: Check what ninject does, because if we dispose this it will crash!
        }
    }
}