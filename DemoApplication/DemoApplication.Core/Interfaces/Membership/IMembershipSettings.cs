namespace DemoApplication.Core.Interfaces.Membership
{
    using System;

    public interface IMembershipSettings
    {
        bool MultiTenant { get; set; }

        string DefaultTenant { get; set; }

        bool EmailIsUsername { get; set; }

        bool UsernamesUniqueAcrossTenants { get; set; }

        bool RequireAccountVerification { get; set; }

        bool AllowLoginAfterAccountCreation { get; set; }

        int AccountLockoutFailedLoginAttempts { get; set; }

        TimeSpan AccountLockoutDuration { get; set; }

        int AccountLockoutMinutes { get; set; }

        bool AllowAccountDeletion { get; set; }

        int MinimumPasswordLength { get; set; }
    }
}