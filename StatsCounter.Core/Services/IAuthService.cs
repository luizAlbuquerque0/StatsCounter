namespace StatsCounter.Core.Services
{
    public interface IAuthService
    {
        string GenerateJWTToken(string email);
        string ComputeSha256Hash(string password);
    }
}
