namespace DemoApplication.Filters.UserContextFilters
{
    using System.Web.Mvc;
    using Core.Common.Profiles;
    using Extensions;
    using Infrastructure.Pipeline;

    public class ChangePasswordRequired : Filter<ActionExecutingContext>
	{
	    public override bool Process(ref ActionExecutingContext data)
	    {
	        if (data.HttpContext.Request.IsAuthenticated)
	        {
	            var user = UserProfile.Current;

                // if password reset is required, redirect to change password page
                if (user.ResetPassword)
                {
                    data.SafeRedirect("ChangePassword", "Account");
                    return false;
                }
            }
	        return true;
	    }
	}
}