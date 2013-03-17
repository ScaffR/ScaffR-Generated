namespace DemoApplication.Core.Interfaces.Eventing
{
    public interface IHandles<T>
    {
        void OnEvent(T e);
    }
}