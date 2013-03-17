namespace DemoApplication.Security.Encryption
{
    #region

    using System.IdentityModel;
    using System.Web.Security;

    #endregion

    public class MachineKeyCookieTransform : CookieTransform
    {
        public override byte[] Decode(byte[] encoded)
        {
            return MachineKey.Unprotect(encoded);
            //return MachineKey.Decode(Encoding.UTF8.GetString(encoded), MachineKeyProtection.All);
        }

        public override byte[] Encode(byte[] value)
        {
            return MachineKey.Protect(value);
            //return Encoding.UTF8.GetBytes(MachineKey.Encode(value, MachineKeyProtection.All));
        }
    }
}
