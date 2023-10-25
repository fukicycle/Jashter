using Blazored.LocalStorage;
using Jashter.Services.Interfaces;

namespace Jashter.Services
{
    public class TokenService : ITokenService
    {
        public readonly ILocalStorageService _localStorageService;
        private readonly ILogger<TokenService> _logger;
        public TokenService(ILocalStorageService localStorageService, ILogger<TokenService> logger)
        {
            _localStorageService = localStorageService;
            _logger = logger;
        }

        public async Task Delete()
        {
            _logger.LogInformation("Delete token");
            await _localStorageService.RemoveItemAsync(ITokenService.KEY);
        }

        public async Task<bool> Exists()
        {
            _logger.LogInformation("Check token");
            return await _localStorageService.ContainKeyAsync(ITokenService.KEY);
        }

        public async Task<string?> GetTokenAsync()
        {
            string? token = await _localStorageService.GetItemAsStringAsync(ITokenService.KEY);
            if (token is null)
            {
                _logger.LogInformation("Token is not found.");
                return null;
            }
            return token;
        }

        public async Task Write(string token)
        {
            _logger.LogInformation("Write token");
            await _localStorageService.SetItemAsStringAsync(ITokenService.KEY, token);
        }
    }
}
