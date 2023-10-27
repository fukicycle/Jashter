using Jashter.Services.Interfaces;
using Jashter.Shared.Dto;

namespace Jashter.Services
{
    public class PartOfSpeechService : IPartOfSpeechService
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<PartOfSpeechService> _logger;
        public PartOfSpeechService(IHttpService httpService, ILogger<PartOfSpeechService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }
        public async Task<IEnumerable<PartOfSpeechResponseDto>> GetPartOfSpeechesAsync()
        {
            IHttpService.HttpResponse<IEnumerable<PartOfSpeechResponseDto>> result = await _httpService.SendAsync<IEnumerable<PartOfSpeechResponseDto>>("part-of-speech", HttpMethod.Get);
            if (result.StatusCode == System.Net.HttpStatusCode.OK && result.Content is not null)
            {
                _logger.LogInformation("Fetching part of speech.");
                return result.Content;
            }
            _logger.LogError(result.ErrorMessage);
            return Enumerable.Empty<PartOfSpeechResponseDto>();
        }
    }
}
