namespace DemoApplication.Core.Services
{
    #region

    using Interfaces.Data;
    using Interfaces.Service;
    using Model;

    #endregion

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