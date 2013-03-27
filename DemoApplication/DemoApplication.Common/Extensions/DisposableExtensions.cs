﻿#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Common
// Author	: Rod Johnson
// Created	: 03-23-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
#region

using System;

#endregion

// ReSharper disable CheckNamespace
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

