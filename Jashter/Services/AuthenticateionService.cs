﻿using Jashter.Services.Interfaces;
using Jashter.Shared.Dto.Request;
using Jashter.Shared.Dto.Response;
using Newtonsoft.Json;

namespace Jashter.Services
{
    public class AuthenticateionService : IAuthenticationService
    {
        private readonly IHttpService _httpService;
        private readonly ITokenService _tokenService;
        private readonly IJsonConvertService _jsonConvertService;
        private readonly ILogger<AuthenticateionService> _logger;
        public AuthenticateionService(IHttpService httpService, ITokenService tokenService, IJsonConvertService jsonConvertService, ILogger<AuthenticateionService> logger)
        {
            _httpService = httpService;
            _tokenService = tokenService;
            _jsonConvertService = jsonConvertService;
            _logger = logger;

        }
        public async Task<bool> LoginAsync(LoginRequestDto loginDto)
        {
            //Delete exists token.
            if (await _tokenService.ExistsAsync())
            {
                await _tokenService.DeleteAsync();
            }
            string content = _jsonConvertService.Serialize(loginDto);
            IHttpService.HttpResponse<LoginResponseDto> result = await _httpService.SendAsync<LoginResponseDto>("login", HttpMethod.Post, content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK && result.Content is not null)
            {
                if (result.Content.Token is not null)
                {
                    await _tokenService.WriteAsync(result.Content.Token);
                    _logger.LogInformation("Login success");
                    return true;
                }
                _logger.LogError("Login success, but token is missing.");
                return false;
            }
            _logger.LogWarning(result.ErrorMessage);
            return false;
        }

        public async Task LogoutAsync()
        {
            await _tokenService.DeleteAsync();
        }
    }
}
