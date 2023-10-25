using System.Security.Principal;

namespace Jashter.Shared.Dto
{
    public class UserResponseDto
    {
        public long ID { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Icon { get; set; }
        public string? Nickname { get; set; }
    }
}
