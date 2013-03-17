namespace DemoApplication.Core.Interfaces.Data
{
    #region

    using Model;

    #endregion

    public interface ITaskRepository : IRepository<Task>
    {
        // Add extra datainterface methods in a partial interface
    }
}
