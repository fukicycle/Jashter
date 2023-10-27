using Jashter.Shared.Dto;

namespace Jashter.Services.Interfaces
{
    public interface IPartOfSpeechService
    {
        Task<IEnumerable<PartOfSpeechResponseDto>> GetPartOfSpeechesAsync();
    }
}
