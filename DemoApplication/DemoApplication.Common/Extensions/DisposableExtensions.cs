#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Common
// Author	: Rod Johnson
// Created	: 03-23-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
#region



#endregion

// ReSharper disable CheckNamespace
namespace DemoApplication.Common.Extensions
{
    #region

    using System;

    #endregion

    public static class DisposableExtensions
        // ReSharper restore CheckNamespace
    {
        public static bool TryDispose(this IDisposable item)
        {
            if (item == null) return false;
            item.Dispose();
            return true;
        }
    }
}

