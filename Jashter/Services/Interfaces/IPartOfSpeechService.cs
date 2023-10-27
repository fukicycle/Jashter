using Jashter.Shared.Dto.Response;

namespace Jashter.Services.Interfaces
{
    public interface IPartOfSpeechService
    {
        Task<IEnumerable<PartOfSpeechResponseDto>> GetPartOfSpeechesAsync();
    }
}
