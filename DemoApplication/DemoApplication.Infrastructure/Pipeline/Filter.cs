#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Pipeline
{
    #region

    using System.Configuration.Provider;

    #endregion

    public abstract class Filter<T> : ProviderBase
    {
        public abstract bool Process(ref T data);
    }
}
