namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using System;

    #endregion

    public interface IDatabaseFactory : IDisposable
    {
        IDataContext Get();
    }
}