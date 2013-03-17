#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Pipeline
{
    #region

    using System.Configuration;

    #endregion

    public interface IPipelineSettings
    {
        string ProcessorType { get; }
        ProviderSettingsCollection Filters { get; }
    }
}