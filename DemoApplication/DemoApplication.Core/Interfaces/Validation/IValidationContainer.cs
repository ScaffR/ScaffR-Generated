namespace DemoApplication.Core.Interfaces.Validation
{
    #region

    using System.Collections.Generic;

    #endregion

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