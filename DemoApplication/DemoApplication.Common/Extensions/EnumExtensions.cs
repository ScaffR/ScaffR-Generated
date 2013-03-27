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
using System.ComponentModel;

#endregion

// ReSharper disable CheckNamespace
public static class EnumExtensions
// ReSharper restore CheckNamespace
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}
