namespace DemoApplication.Filters.UserContextFilters
{
    using System.Web.Mvc;
    using Extensions;
    using Infrastructure.Pipeline;

    public class ChangePasswordRequired : Filter<ActionExecutingContext>
	{
	    public override bool Process(ref ActionExecutingContext data)
	    {
	        if (data.HttpContext.Request.IsAuthenticated)
	        {
                var user = data.Controller.GetCurrentUser();

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