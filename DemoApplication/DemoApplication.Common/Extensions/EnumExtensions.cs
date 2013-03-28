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
    using System.ComponentModel;

    #endregion

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
}

