#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Configuration;

namespace ParadiseBookers.Core.Interfaces.Pipeline
{
    #region

    

    #endregion

    public interface IPipelineSettings
    {
        string ProcessorType { get; }
        ProviderSettingsCollection Filters { get; }
    }
}