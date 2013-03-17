#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Dropdowns
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Dropdowns.Attributes
{
    #region

    using System;

    #endregion

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ExplicitDropdownAttribute : DropDownAttribute
    {
        public ExplicitDropdownAttribute(): base(null, null)
        {
            
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class DropdownOptionAttribute : Attribute
    {
        private string _text;
        private string _value;
        private int _order;

        public DropdownOptionAttribute(string text, string value, int order)
        {
            _order = order;
            _value = value;
            _text = text;
        }

        public string Text
        {
            get { return _text; }
        }

        public string Value
        {
            get { return _value; }
        }

        public int Order
        {
            get { return _order; }
        }
    }
}