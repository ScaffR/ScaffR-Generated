namespace DemoApplication.Infrastructure.Interfaces.Eventing
{
    public interface IHandles<T>
    {
        void OnEvent(T e);
    }
}