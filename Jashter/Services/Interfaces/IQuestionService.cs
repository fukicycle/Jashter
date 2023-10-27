using Jashter.Shared.Dto;

namespace Jashter.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResponseDto>> GetQuestionsAsync();
    }
}
