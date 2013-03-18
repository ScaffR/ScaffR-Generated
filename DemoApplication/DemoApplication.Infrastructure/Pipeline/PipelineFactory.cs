#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Pipeline
{
    #region

    using System;
    using Configuration.Pipeline;
    using Core.Interfaces.Pipeline;

    #endregion

    public static class PipelineFactory
    {
        public static PipelineManager<T> Create<T>(PipelineConfigurationElement pipelineSettings)
        {
            var processor = ((ICoreProcessor<T>) ObjectFactory.Create(pipelineSettings.ProcessorType));

            var filterChain = new FilterChain<T>();

            FilterActivator<T>.InstantiateFilters(pipelineSettings.Filters, filterChain);

            return new PipelineManager<T>(filterChain)
                       {
                           Processor = processor
                       };
        }
                
        private static class ObjectFactory
        {
            public static object Create(string typeName)
            {
                Type t = Type.GetType(typeName);
                return Activator.CreateInstance(t);
            }
        }
    }
}
