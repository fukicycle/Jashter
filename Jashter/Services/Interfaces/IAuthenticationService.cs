using Jashter.Shared.Dto.Request;

namespace Jashter.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(LoginRequestDto loginDto);
        Task LogoutAsync();
    }
}
