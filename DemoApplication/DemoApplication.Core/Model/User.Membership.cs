namespace DemoApplication.Core.Model
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {	
		public string PhotoId { get; set; }
		public virtual ICollection<UserRole> Roles { get; set; }

        public virtual bool IsApproved { get; set; }

        public virtual int PasswordFailuresSinceLastSuccess { get; set; }

        public virtual DateTime? LastPasswordFailureDate { get; set; }

        public virtual DateTime? LastActivityDate { get; set; }

        public virtual DateTime? LastLoginDate { get; set; }

        public virtual bool IsLockedOut { get; set; }

        public virtual DateTime? LastPasswordChangedDate { get; set; }
    }
}