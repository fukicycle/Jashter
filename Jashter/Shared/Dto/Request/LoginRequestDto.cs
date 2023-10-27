using System;

namespace Jashter.Shared.Dto.Request
{
    public class LoginRequestDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

