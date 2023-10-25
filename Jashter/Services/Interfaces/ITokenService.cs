namespace Jashter.Services.Interfaces
{
    public interface ITokenService
    {
        public const string KEY = "JWT";
        Task Write(string token);
        Task<string?> GetTokenAsync();
        Task Delete();
        Task<bool> Exists();
    }
}
