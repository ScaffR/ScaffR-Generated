/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Tokens
{
    using System;
    using System.IdentityModel.Tokens;

    public class SimpleSecurityToken : SecurityToken
    {
        public string Value { get; set; }

        public SimpleSecurityToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(value);
            }

            Value = value;
        }

        #region NotImplemented
        public override string Id
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Collections.ObjectModel.ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get { throw new NotImplementedException(); }
        }

        public override DateTime ValidFrom
        {
            get { throw new NotImplementedException(); }
        }

        public override DateTime ValidTo
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
