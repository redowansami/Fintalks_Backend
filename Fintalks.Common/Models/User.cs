using Fintalks.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Common.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateOnly JoinDate { get; set; }

        public UserRole Role { get; set; }

        public bool isEmailConfirmed { get; set; }

        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
