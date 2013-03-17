namespace DemoApplication.Areas.Api.Controllers
{
    #region

    using Core.Interfaces.Service;
    using Core.Model;

    #endregion

    public partial class TaskController : ApiController<Task>
    {
        protected ITaskService TaskService;

        public TaskController(ITaskService service)
        {
            Service = TaskService = service;
        }
    }
}