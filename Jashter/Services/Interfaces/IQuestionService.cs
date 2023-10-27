using Jashter.Shared.Dto.Response;

namespace Jashter.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResponseDto>> GetQuestionsAsync();
    }
}
