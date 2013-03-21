#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Extensions
{
    #region

    using System;

    #endregion

    public static class DisposableExtensions
    {
        public static bool TryDispose(this IDisposable item)
        {
            if (item == null) return false;
            item.Dispose();
            return true;
        }
    }
}
