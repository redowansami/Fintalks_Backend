using Fintalks.Common.Enums;

namespace Fintalks.Common.Models
{
    public class User
    {
        public Guid UserID { get; set; } = new Guid();
        public required string UserName { get; set; }
        public required string Name { get; set; }

        public required string Email { get; set; }
        public DateOnly JoinDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public UserRole Role { get; set; } = UserRole.USER;

        public bool isEmailConfirmed { get; set; } = false;

        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DeletedAt { get; set; }

        public override string ToString()
        {
            return $"UserResponseDTO [UserID={UserID}, UserName={UserName}, Name={Name}, Email={Email}, JoinDate={JoinDate}, isEmail={isEmailConfirmed} Role={Role}, Bio={Bio ?? "null"}, ProfilePictureUrl={ProfilePictureUrl ?? "null"}, DeletedAt={DeletedAt}]";
        }
    }
}
