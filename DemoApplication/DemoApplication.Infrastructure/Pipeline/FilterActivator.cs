#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Pipeline
{
    #region

    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    #endregion

    /// <summary>
    /// The pipeline activator.
    /// </summary>
    public static class FilterActivator<T>
    {
        public static void InstantiateFilters(
            ProviderSettingsCollection settings, FilterChain<T> sections)
        {
            foreach (ProviderSettings setting in settings)
            {
                sections.Add(InstantiateFilter(setting));
            }
        }

        public static Filter<T> InstantiateFilter(ProviderSettings settings)
        {
            Filter<T> filter = null;
            try
            {
                string typeName = (settings.Type == null) ? null : settings.Type.Trim();
                if (string.IsNullOrEmpty(typeName))
                {
                    throw new ArgumentException("'Type' is required");
                }

                Type t = Type.GetType(typeName);

                Type pipelineType = typeof(Filter<T>);

                if (!pipelineType.IsAssignableFrom(t))
                {
                    throw new ArgumentException("wrong type");
                }

                filter = (Filter<T>)Activator.CreateInstance(t, false);
                filter.Initialize(settings.Name, settings.Parameters);

                var parameters = settings.Parameters;
                var cloneParameters = new NameValueCollection(parameters.Count, StringComparer.Ordinal);

                foreach (string param in parameters)
                {
                    cloneParameters[param] = parameters[param];
                }
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return filter;
        }
    }
}
