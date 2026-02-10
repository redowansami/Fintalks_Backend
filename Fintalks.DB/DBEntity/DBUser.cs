using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Fintalks.Common.Enums;

namespace Fintalks.DB.DBEntity
{
    public class DBUser
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateOnly JoinDate { get; set; }

        public UserRole Role { get; set; }

        public bool isEmailConfirmed { get; set; }

        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
