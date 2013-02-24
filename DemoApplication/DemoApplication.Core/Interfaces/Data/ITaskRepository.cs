namespace DemoApplication.Core.Interfaces.Data
{
    using Model;

    public interface ITaskRepository : IRepository<Task>
    {
        // Add extra datainterface methods in a partial interface
    }
}
