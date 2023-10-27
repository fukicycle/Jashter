using Jashter.Shared.Dto.Response;

namespace Jashter.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto?> GetUserAsync();
    }
}
