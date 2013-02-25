namespace DemoApplication.Core.Common.Security
{
    using System;

    public class ResourceAction
    {
        public readonly string Resource;
        public readonly string Action;

        public override bool Equals(object obj)
        {
            var ra = obj as ResourceAction;
            if (ra != null)
            {
                return ((string.Compare(ra.Resource, Resource, true) == 0) &&
                        (string.Compare(ra.Action, Action, true) == 0));
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (Resource + Action).ToLower().GetHashCode();
        }

        public ResourceAction(string resource, string action)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException("resource");
            }

            Resource = resource;
            Action = action;
        }
    }
}
