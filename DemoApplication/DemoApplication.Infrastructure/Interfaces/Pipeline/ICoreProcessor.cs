namespace DemoApplication.Infrastructure.Interfaces.Pipeline
{
    public interface ICoreProcessor<in T>
    {
        void Execute(T data);
    }
}
