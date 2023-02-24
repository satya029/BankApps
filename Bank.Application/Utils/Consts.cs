namespace Bank.Application.Utils
{
    public static class Consts
    {
        public const string UserRole = "USER";
        public const string JWTKEY = "SecretKey1234SecretKey1234SecretKey1234SecretKey1234SecretKey1234SecretKey1234SecretKey1234SecretKey1234SecretKey1234";
        public const string Issuer = "issuer";
        public const string Audience = "audience";
        public const string Authorization = "Authorization";
        public const string SpecificOrigins = "_specificOrigins";
        public static DateTime TokenExpirationTime = DateTime.UtcNow.AddMinutes(60);
    }
}
