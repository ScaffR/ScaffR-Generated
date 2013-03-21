#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Pipeline
{
    #region

    using Core.Interfaces.Pipeline;

    #endregion

    public class PipelineManager<T>
	{
        private readonly FilterChain<T> _filters;
        private ICoreProcessor<T> _processor;

        public PipelineManager()
        {
            _filters = new FilterChain<T>();
        }

        public PipelineManager(FilterChain<T> filters)
		{
			_filters = filters;
		}

        internal FilterChain<T> Filters
        {
            get { return _filters; }
        }

        internal ICoreProcessor<T> Processor
        {
            get { return _processor; }
            set { _processor = value; }
        }

		public bool Process(ref T data, bool stopOnFailure)
		{
            bool success = _filters.Process(ref data, stopOnFailure);
            if (!stopOnFailure && success && _processor != null)
                _processor.Execute(data);
            
            return success;
		}

        public bool Process(ref T data)
        {
            return Process(ref data, false);
        }
	}
}
