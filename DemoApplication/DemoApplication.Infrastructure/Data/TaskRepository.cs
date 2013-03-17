namespace DemoApplication.Infrastructure.Data
{
    #region

    using Core.Interfaces.Data;
    using Core.Model;

    #endregion

    public partial class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
		public TaskRepository(IDatabaseFactory databaseFactory)
	        : base(databaseFactory)
	    {
	    }
	}
}