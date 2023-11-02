using Jashter.Shared.Dto.Response;
using Jashter.Shared.Dto.Request;

namespace Jashter.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResponseDto>> GetQuestionsAsync(QuestionRequestDto questionRequestDto);
    }
}
