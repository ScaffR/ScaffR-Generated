namespace DemoApplication.Core.Common.Security
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using System.Xml;

    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        static readonly Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>> Policies = new Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>>();
        readonly PolicyReader _policyReader = new PolicyReader();

        public override bool CheckAccess(AuthorizationContext context)
        {
            bool access;
            try
            {
                var ra = new ResourceAction(context.Resource.First().Value, context.Action.First().Value);

                access = Policies[ra](context.Principal);
            }
            catch (Exception)
            {
                // exception is ok here, just implies false
                access = false;
            }

            return access;
        }        

        public override void LoadCustomConfiguration(XmlNodeList nodelist)
        {
            foreach(XmlNode node in nodelist)
            {
                XmlDictionaryReader rdr =
                    XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(new StringReader(node.OuterXml)));
                rdr.MoveToContent();

                string resource = rdr.GetAttribute("resource");
                string action = rdr.GetAttribute("action");

                Expression<Func<ClaimsPrincipal, bool>> policyExpression = _policyReader.ReadPolicy(rdr);

                Func<ClaimsPrincipal, bool> policy = policyExpression.Compile();

                Policies[new ResourceAction(resource, action)] = policy;
            }
        }
    }
}
