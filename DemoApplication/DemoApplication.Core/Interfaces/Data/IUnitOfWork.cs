namespace DemoApplication.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}