/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Authorization.Todo
{
    using System.Web.Http.Controllers;

    public interface IAuthorizationManager
    {
        bool CheckAccess(HttpActionContext context);
    }
}