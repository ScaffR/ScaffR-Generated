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

using System.Collections.Generic;

namespace ParadiseBookers.Infrastructure.Pipeline
{
    #region

    

    #endregion

    public class FilterChain<T> : List<Filter<T>>
    {
        internal bool Process(ref T data, bool stopOnFailure)
        {
            bool success = true;
            foreach (Filter<T> processor in this)
            {
                if (!processor.Process(ref data))
                    success = false;

                if (stopOnFailure && !success)
                    break;
            }
            return success;
        }

        internal bool Process(ref T data)
        {
            return Process(ref data, false);
        }
    }
}
