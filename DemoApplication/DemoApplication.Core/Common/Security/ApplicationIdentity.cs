namespace DemoApplication.Core.Common.Security
{
    using System;
    using System.Globalization;
    using System.Security.Claims;
    using Model;

    public sealed partial class ApplicationIdentity : ClaimsIdentity
    {
        partial void SetCustomIdentityClaims(User user);

        public ApplicationIdentity(User user) : base("Application")
        {
            if (user== null)
            {
                throw new ArgumentException("user");
            }

            AddClaim(new Claim(ClaimTypes.Name, user.Username));     
            AddClaim(new Claim(ApplicationClaimTypes.UserId, user.Id.ToString(CultureInfo.InvariantCulture)));
            AddClaim(new Claim("Time", DateTime.Now.ToString()));

            SetCustomIdentityClaims(user);
        }

        public int UserId
        {
            get { return int.Parse(FindFirst(ApplicationClaimTypes.UserId).Value); }
        }

        public string Username
        {
            get { return FindFirst(ClaimTypes.Name).Value; }
        }

    }
}
