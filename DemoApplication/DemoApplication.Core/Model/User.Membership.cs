#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Model
{
    #region

    using System;

    #endregion

    public partial class User
    {	
		public string PhotoId { get; set; }

        public virtual bool IsApproved { get; set; }

        public virtual int PasswordFailuresSinceLastSuccess { get; set; }

        public virtual DateTime? LastPasswordFailureDate { get; set; }

        public virtual DateTime? LastActivityDate { get; set; }

        public virtual DateTime? LastLoginDate { get; set; }

        public virtual bool IsLockedOut { get; set; }

        public virtual DateTime? LastPasswordChangedDate { get; set; }

    }
}