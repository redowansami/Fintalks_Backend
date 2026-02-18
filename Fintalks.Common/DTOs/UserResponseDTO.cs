using System.ComponentModel.DataAnnotations.Schema;
using Fintalks.Common.Enums;

namespace Fintalks.Common.DTOs
{
    public class UserResponseDTO
    {
        public Guid UserID { get; set; }
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateOnly JoinDate { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public UserRole Role { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public override string ToString()
        {
            return $"UserResponseDTO [UserID={UserID}, UserName={UserName}, Name={Name}, Email={Email}, JoinDate={JoinDate}, Role={Role}, Bio={Bio ?? "null"}, ProfilePictureUrl={ProfilePictureUrl ?? "null"}]";
        }
    }
}
