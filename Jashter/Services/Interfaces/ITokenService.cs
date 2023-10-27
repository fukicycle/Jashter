namespace Jashter.Services.Interfaces
{
    public interface ITokenService
    {
        public const string KEY = "JWT";
        Task WriteAsync(string token);
        Task<string?> GetTokenAsync();
        Task DeleteAsync();
        Task<bool> ExistsAsync();
    }
}
