#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Configuration.Provider;

namespace ParadiseBookers.Infrastructure.Pipeline
{
    #region

    

    #endregion

    public abstract class Filter<T> : ProviderBase
    {
        public abstract bool Process(ref T data);
    }
}
