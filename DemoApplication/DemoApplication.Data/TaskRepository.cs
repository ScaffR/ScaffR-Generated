namespace DemoApplication.Data
{
    using DemoApplication.Core.Interfaces.Data;
    using DemoApplication.Core.Model;

    public partial class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
		public TaskRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}