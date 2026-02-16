using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Enums;

namespace Fintalks.Common.DTOs
{
    public class UserResponseDTO
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateOnly JoinDate { get; set; }

        public UserRole Role { get; set; }

        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public override string ToString()
        {
            return $"UserResponseDTO [UserID={UserID}, UserName={UserName}, Name={Name}, Email={Email}, JoinDate={JoinDate}, Role={Role}, Bio={Bio ?? "null"}, ProfilePictureUrl={ProfilePictureUrl ?? "null"}]";
        }
    }
}
