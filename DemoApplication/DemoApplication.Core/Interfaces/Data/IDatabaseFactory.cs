namespace DemoApplication.Core.Interfaces.Data
{
    using System;

    public interface IDatabaseFactory : IDisposable
    {
        IDataContext Get();
    }
}