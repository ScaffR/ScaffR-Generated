#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ParadiseBookers.Metadata.Attributes;
using ParadiseBookers.Metadata.Rules;

namespace ParadiseBookers.Metadata.Adapters
{
    #region

    

    #endregion

    public class NumericAttributeAdapter : DataAnnotationsModelValidator<NumericTextboxAttribute>
    {
        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>(new Type[] {
            typeof(byte), typeof(sbyte),
            typeof(short), typeof(ushort),
            typeof(int), typeof(uint),
            typeof(long), typeof(ulong),
            typeof(float), typeof(double), typeof(decimal)
        });

        public NumericAttributeAdapter(ModelMetadata metadata, ControllerContext context, NumericTextboxAttribute textboxAttribute)
            : base(metadata, context, textboxAttribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            //Don't add a client validator if the datatype is numeric (the mvc framework will handle that for us)
            Type type = Metadata.ModelType;
            if (!IsNumericType(type))
            {
                yield return new ModelClientValidationNumericRule(ErrorMessage);
            }
        }

        private static bool IsNumericType(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type); // strip off the Nullable<>
            return NumericTypes.Contains(underlyingType ?? type);
        }
    }
}