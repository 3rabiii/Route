namespace Shared;

public class JwtOptions
{
    public string issuer  { get; set; }
    public string audience { get; set; }
    public string secretKey { get; set; }
    public double expirationInDays { get; set; }
}