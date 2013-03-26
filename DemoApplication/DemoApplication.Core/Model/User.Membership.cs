#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Model
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using DemoApplication.Common.Crypto;
    using DemoApplication.Common.Tracing;
    using Interfaces.Membership;

    #endregion

    [DisplayColumn("Username")]
    public partial class User : DomainObject
    {
        static User()
        {
            settings = DependencyResolver.Current.GetService<IMembershipSettings>();
        }

        internal const string ChangeEmailVerificationPrefix = "changeEmail";
        internal const int VerificationKeyStaleDurationDays = 1;

        private static IMembershipSettings settings;

        public User()
        {
            Claims = new List<UserClaim>();
        }

        internal protected User(string tenant, string username, string password, string email)
        {
            if (String.IsNullOrWhiteSpace(tenant)) throw new ArgumentException("tenant");
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentException("username");
            if (String.IsNullOrWhiteSpace(password)) throw new ArgumentException("password");
            if (String.IsNullOrWhiteSpace(email)) throw new ArgumentException("email");

            this.Tenant = tenant;
            this.Username = username;
            this.Email = email;
            this.Created = this.UtcNow;
            this.SetPassword(password);
            this.IsAccountVerified = !settings.RequireAccountVerification;
            this.IsLoginAllowed = settings.AllowLoginAfterAccountCreation;
            this.Claims = new List<UserClaim>();

            if (settings.RequireAccountVerification)
            {
                this.VerificationKey = StripUglyBase64(this.GenerateSalt());
                this.VerificationKeySent = this.UtcNow;
            }
        }

        [Key]
        public virtual int ID { get; set; }

        [StringLength(50)]
        [Required]
        public virtual string Tenant { get; set; }
        [StringLength(100)]
        [Required]
        public virtual string Username { get; set; }
        [EmailAddress]
        [StringLength(100)]
        [Required]
        public virtual string Email { get; set; }

        public virtual DateTime PasswordChanged { get; set; }

        public virtual bool IsAccountVerified { get; set; }
        public virtual bool IsLoginAllowed { get; set; }
        public virtual bool IsAccountClosed { get; set; }
        public virtual DateTime? AccountClosed { get; set; }

        public virtual DateTime? LastLogin { get; set; }
        public virtual DateTime? LastFailedLogin { get; set; }
        public virtual int FailedLoginCount { get; set; }

        [StringLength(100)]
        public virtual string VerificationKey { get; set; }
        public virtual DateTime? VerificationKeySent { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string HashedPassword { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }

        protected internal virtual bool VerifyAccount(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                Tracing.Verbose("[UserAccount.VerifyAccount] failed -- no key");
                return false;
            }
            if (IsAccountVerified)
            {
                Tracing.Verbose("[UserAccount.VerifyAccount] failed -- account already verified");
                return false;
            }
            if (this.VerificationKey != key)
            {
                Tracing.Verbose("[UserAccount.VerifyAccount] failed -- verification key doesn't match");
                return false;
            }

            this.IsAccountVerified = true;
            this.VerificationKey = null;
            this.VerificationKeySent = null;

            return true;
        }

        protected internal virtual bool ChangePassword(string oldPassword, string newPassword, int failedLoginCount, TimeSpan lockoutDuration)
        {
            if (Authenticate(oldPassword, failedLoginCount, lockoutDuration))
            {
                if (oldPassword == newPassword)
                {
                    Tracing.Verbose(String.Format("[UserAccount.ChangePassword] failed for tenant:user {0}:{1} -- new password same as old password", this.Tenant, this.Username));

                    throw new ValidationException("The new password must be different than the old password.");
                }

                SetPassword(newPassword);
                return true;
            }

            Tracing.Verbose(String.Format("[UserAccount.ChangePassword] failed for tentant:username {0}:{1} -- auth failed", this.Tenant, this.Username));

            return false;
        }

        protected internal virtual void SetPassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Verbose("[UserAccount.SetPassword] failed -- no password provided");

                throw new ValidationException("Invalid password");
            }

            Tracing.Verbose("[UserAccount.SetPassword] setting new password hash");

            HashedPassword = HashPassword(password);
            PasswordChanged = UtcNow;
        }

        protected internal virtual bool IsVerificationKeyStale
        {
            get
            {
                if (VerificationKeySent == null)
                {
                    return true;
                }

                if (this.VerificationKeySent < UtcNow.AddDays(-VerificationKeyStaleDurationDays))
                {
                    return true;
                }

                return false;
            }
        }

        protected internal virtual bool ResetPassword()
        {
            // if they've not yet verified then don't allow changes
            if (!this.IsAccountVerified)
            {
                Tracing.Verbose("[UserAccount.ResetPassword] failed -- account not verified");

                return false;
            }

            // if there's no current key, or if there is a key but 
            // it's older than one day, create a new reset key
            if (IsVerificationKeyStale)
            {
                Tracing.Verbose("[UserAccount.ResetPassword] creating new verification keys");

                this.VerificationKey = StripUglyBase64(GenerateSalt());
                this.VerificationKeySent = UtcNow;
            }
            else
            {
                Tracing.Verbose("[UserAccount.ResetPassword] not creating new verification keys");
            }

            return true;
        }

        protected internal virtual bool ChangePasswordFromResetKey(string key, string newPassword)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                Tracing.Verbose("[UserAccount.ChangePasswordFromResetKey] failed -- no key");
                return false;
            }

            if (!this.IsAccountVerified)
            {
                Tracing.Verbose("[UserAccount.ChangePasswordFromResetKey] failed -- account not verified");
                return false;
            }

            // if the key is too old don't honor it
            if (IsVerificationKeyStale)
            {
                Tracing.Verbose("[UserAccount.ChangePasswordFromResetKey] failed -- verification key too old");
                return false;
            }

            // check if key matches
            if (this.VerificationKey != key)
            {
                Tracing.Verbose("[UserAccount.ChangePasswordFromResetKey] failed -- verification keys don't match");
                return false;
            }

            this.VerificationKey = null;
            this.VerificationKeySent = null;
            this.SetPassword(newPassword);

            return true;
        }

        protected internal virtual bool Authenticate(string password, int failedLoginCount, TimeSpan lockoutDuration)
        {
            if (failedLoginCount <= 0) throw new ArgumentException("failedLoginCount");

            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Verbose("[UserAccount.Authenticate] failed -- no password");
                return false;
            }

            if (!IsAccountVerified)
            {
                Tracing.Verbose("[UserAccount.Authenticate] failed -- account not verified");
                return false;
            }
            if (!IsLoginAllowed)
            {
                Tracing.Verbose("[UserAccount.Authenticate] failed -- account not allowed to login");
                return false;
            }

            if (HasTooManyRecentPasswordFailures(failedLoginCount, lockoutDuration))
            {
                Tracing.Verbose("[UserAccount.Authenticate] failed -- account in lockout due to failed login attempts");

                FailedLoginCount++;
                return false;
            }

            var valid = VerifyHashedPassword(password);
            if (valid)
            {
                Tracing.Verbose("[UserAccount.Authenticate] authentication success");

                LastLogin = UtcNow;
                FailedLoginCount = 0;
            }
            else
            {
                Tracing.Verbose("[UserAccount.Authenticate] failed -- invalid password");

                LastFailedLogin = UtcNow;
                if (FailedLoginCount > 0) FailedLoginCount++;
                else FailedLoginCount = 1;
            }

            return valid;
        }

        protected internal virtual bool HasTooManyRecentPasswordFailures(int failedLoginCount, TimeSpan lockoutDuration)
        {
            if (failedLoginCount <= 0) throw new ArgumentException("failedLoginCount");

            if (failedLoginCount <= FailedLoginCount)
            {
                return LastFailedLogin >= UtcNow.Subtract(lockoutDuration);
            }

            return false;
        }

        protected internal virtual bool ChangeEmailRequest(string newEmail)
        {
            if (String.IsNullOrWhiteSpace(newEmail)) throw new ValidationException("Invalid email.");

            // if they've not yet verified then fail
            if (!this.IsAccountVerified)
            {
                Tracing.Verbose("[UserAccount.ChangeEmailRequest] failed -- account not verified");
                return false;
            }

            var lowerEmail = newEmail.ToLower(new System.Globalization.CultureInfo("tr-TR", false));
            var emailHash = StripUglyBase64(Hash(ChangeEmailVerificationPrefix + lowerEmail));

            // if there's no current key, or it's not a change email key
            // or if there is a key but it's older than one day, then create 
            // a new reset key
            if (IsVerificationKeyStale ||
                this.VerificationKey == null ||
                !this.VerificationKey.StartsWith(emailHash))
            {
                Tracing.Verbose("[UserAccount.ChangeEmailRequest] creating a new reset key");

                var random = StripUglyBase64(GenerateSalt());
                this.VerificationKey = emailHash + random;
                this.VerificationKeySent = UtcNow;
            }
            else
            {
                Tracing.Verbose("[UserAccount.ChangeEmailRequest] not creating a new reset key");
            }

            return true;
        }

        protected internal virtual bool ChangeEmailFromKey(string key, string newEmail)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                Tracing.Verbose("[UserAccount.ChangeEmailFromKey] failed -- no key");
                return false;
            }
            if (String.IsNullOrWhiteSpace(newEmail)) throw new ValidationException("Invalid email.");

            // only honor resets within the past day
            if (!IsVerificationKeyStale)
            {
                if (key == this.VerificationKey)
                {
                    var lowerEmail = newEmail.ToLower(new System.Globalization.CultureInfo("tr-TR", false));
                    var emailHash = StripUglyBase64(Hash(ChangeEmailVerificationPrefix + lowerEmail));
                    if (this.VerificationKey.StartsWith(emailHash))
                    {
                        this.Email = newEmail;
                        this.VerificationKey = null;
                        this.VerificationKeySent = null;

                        return true;
                    }
                    else
                    {
                        Tracing.Verbose("[UserAccount.ChangeEmailFromKey] failed -- verification key is not marked as a email change verificaiton key");
                    }
                }
                else
                {
                    Tracing.Verbose("[UserAccount.ChangeEmailFromKey] failed -- verification keys don't match");
                }
            }
            else
            {
                Tracing.Verbose("[UserAccount.ChangeEmailFromKey] failed -- verification key is stale");
            }

            return false;
        }

        protected internal virtual void CloseAccount()
        {
            Tracing.Verbose(String.Format("[UserAccount.CloseAccount] called on: {0}, {0}", Tenant, Username));

            IsLoginAllowed = false;
            IsAccountClosed = true;
            AccountClosed = UtcNow;
        }

        protected internal virtual bool IsPasswordExpired
        {
            get
            {
                var frequency = settings.PasswordResetFrequency;
                if (frequency <= 0) return false;

                var now = this.UtcNow;
                var last = this.PasswordChanged;
                return last.AddDays(frequency) <= now;
            }
        }

        public virtual bool HasClaim(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            return this.Claims.Any(x => x.Type == type);
        }

        public virtual bool HasClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value");

            return this.Claims.Any(x => x.Type == type && x.Value == value);
        }

        public virtual IEnumerable<string> GetClaimValues(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            var query =
                from claim in this.Claims
                where claim.Type == type
                select claim.Value;
            return query.ToArray();
        }

        public virtual string GetClaimValue(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            var query =
                from claim in this.Claims
                where claim.Type == type
                select claim.Value;
            return query.SingleOrDefault();
        }

        public virtual void AddClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value");

            if (!this.HasClaim(type, value))
            {
                Tracing.Verbose(String.Format("[UserAccount.AddClaim] {0}, {1}, {2}, {3}", Tenant, Username, type, value));

                this.Claims.Add(
                    new UserClaim
                    {
                        Type = type,
                        Value = value
                    });
            }
        }

        public virtual void RemoveClaim(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            var claimsToRemove =
                from claim in this.Claims
                where claim.Type == type
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                Tracing.Verbose(String.Format("[UserAccount.RemoveClaim] {0}, {1}, {2}, {3}", Tenant, Username, type, claim.Value));
                this.Claims.Remove(claim);
            }
        }

        public virtual void RemoveClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value");

            var claimsToRemove =
                from claim in this.Claims
                where claim.Type == type && claim.Value == value
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                Tracing.Verbose(String.Format("[UserAccount.RemoveClaim] {0}, {1}, {2}, {3}", Tenant, Username, type, value));
                this.Claims.Remove(claim);
            }
        }

        static readonly string[] UglyBase64 = { "+", "/", "=" };
        static string StripUglyBase64(string s)
        {
            if (s == null) return s;
            foreach (var ugly in UglyBase64)
            {
                s = s.Replace(ugly, "");
            }
            return s;
        }

        protected internal virtual string Hash(string value)
        {
            return CryptoHelper.Hash(value);
        }

        protected internal virtual string GenerateSalt()
        {
            return CryptoHelper.GenerateSalt();
        }

        protected internal virtual string HashPassword(string password)
        {
            return CryptoHelper.HashPassword(password, settings.PasswordHashingIterationCount);
        }

        protected internal virtual bool VerifyHashedPassword(string password)
        {
            return CryptoHelper.VerifyHashedPassword(HashedPassword, password);
        }

        protected internal virtual DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

    }
}