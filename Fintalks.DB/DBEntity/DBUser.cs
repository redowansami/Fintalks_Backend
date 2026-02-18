using Fintalks.Common.Enums;
using Fintalks.Common.Interfaces;

namespace Fintalks.DB.DBEntity
{
    public class DBUser : ISoftDeletable
    {
        public Guid UserID { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public DateOnly JoinDate { get; set; }
        public UserRole Role { get; set; }
        public bool isEmailConfirmed { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DeletedAt { get; set; }

        public override string ToString()
        {
            return $"DBUser [UserID={UserID}, UserName={UserName}, Name={FirstName}--{LastName}, Email={Email}, JoinDate={JoinDate}, Role={Role}, Confirmed={isEmailConfirmed}, Bio={Bio ?? "null"}, ProfilePic={ProfilePictureUrl ?? "null"}, DeletedAt={DeletedAt?.ToString() ?? "null"}]";
        }
    }
}
