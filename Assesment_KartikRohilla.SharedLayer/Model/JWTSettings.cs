namespace Assesment_KartikRohilla.SharedLayer.Model
{
    public class JWTSettings
    {
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public string SecretKey { get; set; } = "";
        public int ExpireInMinutes { get; set; } = 0;
    }
}
