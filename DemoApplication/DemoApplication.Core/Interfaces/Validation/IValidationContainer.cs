namespace DemoApplication.Core.Interfaces.Validation
{
    using System.Collections.Generic;

    public interface IValidationContainer<out T> : IValidationContainer
    {        
        T Entity { get;  }
    }

    public interface IValidationContainer
    {
        IDictionary<string, IList<string>> ValidationErrors { get; }
        bool IsValid { get; }
    }
}