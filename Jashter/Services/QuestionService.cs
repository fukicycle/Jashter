using Jashter.Services.Interfaces;
using Jashter.Shared.Dto.Response;

namespace Jashter.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<QuestionService> _logger;
        public QuestionService(IHttpService httpService, ILogger<QuestionService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }
        public async Task<IEnumerable<QuestionResponseDto>> GetQuestionsAsync()
        {
            IHttpService.HttpResponse<IEnumerable<QuestionResponseDto>> result = await _httpService.SendAsync<IEnumerable<QuestionResponseDto>>("question", HttpMethod.Get);
            if (result.StatusCode == System.Net.HttpStatusCode.OK && result.Content is not null)
            {
                _logger.LogInformation("Fetching questions.");
                return result.Content;
            }
            _logger.LogError(result.ErrorMessage);
            return Enumerable.Empty<QuestionResponseDto>();
        }
    }
}
