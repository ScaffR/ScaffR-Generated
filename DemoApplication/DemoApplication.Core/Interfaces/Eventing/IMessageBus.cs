namespace DemoApplication.Core.Interfaces.Eventing
{
    public interface IMessageBus
    {
        void Subscribe(object subscriber);
        void Publish<TEvent>(TEvent eventToPublish);
    }
}
