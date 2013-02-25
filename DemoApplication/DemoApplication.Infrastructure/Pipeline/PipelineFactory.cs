namespace DemoApplication.Infrastructure.Pipeline
{
    using System;
    using Configuration.Pipeline;
    using Interfaces.Pipeline;

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
