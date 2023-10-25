using Jashter.Services.Interfaces;
using Jashter.Shared.Dto;

namespace Jashter.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;
        public UserService(IHttpService httpService, ITokenService tokenService, ILogger<UserService> logger)
        {
            _httpService = httpService;
            _tokenService = tokenService;
            _logger = logger;
        }
        public async Task<UserResponseDto?> GetUserAsync()
        {
            if (await _tokenService.Exists())
            {
                IHttpService.HttpResponse<UserResponseDto> result = await _httpService.SendAsync<UserResponseDto>("user", HttpMethod.Get);
                if (result.StatusCode == System.Net.HttpStatusCode.OK && result.Content is not null)
                {
                    _logger.LogInformation("Fetching user information.");
                    return result.Content;
                }
                _logger.LogWarning(result.ErrorMessage);
        }
            else
            {
                _logger.LogInformation("No token found.");
            }
            return null;
        }
    }
}
