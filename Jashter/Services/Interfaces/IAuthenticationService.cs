using Jashter.Shared.Dto;

namespace Jashter.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginDto loginDto);
        void Logout();
    }
}
