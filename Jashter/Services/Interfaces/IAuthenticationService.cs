using Jashter.Shared.Dto;

namespace Jashter.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginRequestDto loginDto);
        void Logout();
    }
}
