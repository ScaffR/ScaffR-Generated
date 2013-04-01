using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.Core.Common.Membership
{
    public interface IUserInfoEvent
    {
        string Tenant { get; }
        string Username { get; }
    }
}
