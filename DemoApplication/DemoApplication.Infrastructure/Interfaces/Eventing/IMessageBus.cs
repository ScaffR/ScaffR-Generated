namespace DemoApplication.Infrastructure.Interfaces.Eventing
{
    public interface IMessageBus
    {
        void Subscribe(object subscriber);
        void Publish<TEvent>(TEvent eventToPublish);
    }
}
