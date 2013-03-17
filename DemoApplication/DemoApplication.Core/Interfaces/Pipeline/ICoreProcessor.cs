namespace DemoApplication.Core.Interfaces.Pipeline
{
    public interface ICoreProcessor<in T>
    {
        void Execute(T data);
    }
}
