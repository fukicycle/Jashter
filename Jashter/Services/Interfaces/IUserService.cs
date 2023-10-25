using Jashter.Shared.Dto;

namespace Jashter.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto?> GetUserAsync();
    }
}
