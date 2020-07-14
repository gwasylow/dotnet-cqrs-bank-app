using System;

namespace CQRS.BankApp.Core.Utils
{
    public static class Consts
    {
        public const string UserRole = "USER";
        public const string JWTKEY = "TopSecretKeyTopSecretKeyTopSecretKeyTopSecretKeyTopSecretKeyTopSecretKeyTopSecretKeyTopSecretKey";
        public const string Issuer = "issuer";
        public const string Audience = "audience";
        public const string Authorization = "Authorization";
        public static DateTime TokenExpirationTime = DateTime.UtcNow.AddMinutes(60);
    }
}
