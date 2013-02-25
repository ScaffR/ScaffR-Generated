namespace DemoApplication.Core.Interfaces.Validation
{
    using System.Collections.Generic;

    public interface IValidationContainer<out T>
    {
        IDictionary<string, IList<string>> ValidationErrors { get; }
        bool IsValid { get; }
        T Entity { get;  }
    }
}