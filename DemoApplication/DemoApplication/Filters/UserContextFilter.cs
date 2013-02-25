namespace DemoApplication.Filters
{
    using System.Web.Mvc;
    using Infrastructure.Pipeline;
    using UserContextFilters;

    public partial class UserContextFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var filters = new FilterChain<ActionExecutingContext>();
            RegisterFilters(filters);
            new PipelineManager<ActionExecutingContext>(filters).Process(ref filterContext, true);
            base.OnActionExecuting(filterContext);
        }

        public void RegisterFilters(FilterChain<ActionExecutingContext> filters)
        {
            filters.Add(new SetProfileValues());
            filters.Add(new ChangePasswordRequired());
        }
    }
}