﻿#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-23-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace ParadiseBookers.Core.Interfaces.Membership
{
    public interface IPasswordPolicy
    {
        string PolicyMessage { get; }
        bool ValidatePassword(string password);
    }
}
