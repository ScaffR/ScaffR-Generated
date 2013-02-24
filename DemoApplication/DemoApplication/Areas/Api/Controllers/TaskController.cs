namespace DemoApplication.Areas.Api.Controllers
{
    using Core.Interfaces.Service;
    using Core.Model;

    public partial class TaskController : ApiController<Task>
    {
        protected ITaskService TaskService;

        public TaskController(ITaskService service)
        {
            Service = TaskService = service;
        }
    }
}