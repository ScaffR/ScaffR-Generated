namespace DemoApplication.Filters.UserContextFilters
{
    using System.Web.Mvc;
    using Core.Common.Profiles;
    using Infrastructure.Pipeline;

    public class SetProfileValues : Filter<ActionExecutingContext>
	{
	    public override bool Process(ref ActionExecutingContext data)
	    {
	        if (data.HttpContext.Request.IsAuthenticated)
	        {
	            var user = UserProfile.Current;

                if (user == null)
                {
                    return false;
                }
                var vb = data.Controller.ViewBag;
                vb.CurrentUser = user;
            }
	        return true;
	    }
	}
}