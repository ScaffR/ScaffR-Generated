namespace DemoApplication.Service
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Interfaces.Service;
    using DemoApplication.Core.Model;

    public partial class TaskService : BaseService<Task>, ITaskService
    {
		protected new ITaskRepository TaskRepository;

        public TaskService(IUnitOfWork unitOfWork, ITaskRepository taskRepository)
			:base(unitOfWork)
		{
            base.Repository = TaskRepository = taskRepository;
		}		
	}
}