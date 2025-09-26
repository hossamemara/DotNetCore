namespace DotNetCore.ConfigurationClasses
{
    public class JwtOptions
    {

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTimeMyProperty { get; set; }
        public string SigningKey { get; set; }
    }
}
