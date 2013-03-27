#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Interfaces.Pipeline
{
    public interface ICoreProcessor<in T>
    {
        void Execute(T data);
    }
}
