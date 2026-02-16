using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Fintalks.Common.Enums;

namespace Fintalks.DB.DBEntity
{
    public class DBUser
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression(
            @"^[a-zA-Z0-9_]+$",
            ErrorMessage = "Alphabet, Digits and _ allowed only"
        )]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        public DateOnly JoinDate { get; set; }
        public UserRole Role { get; set; }
        public bool isEmailConfirmed { get; set; }

        [MaxLength(500)]
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DeletedAt { get; set; }

        public override string ToString()
        {
            return $"DBUser [UserID={UserID}, UserName={UserName}, Name={FirstName}--{LastName}, Email={Email}, JoinDate={JoinDate}, Role={Role}, Confirmed={isEmailConfirmed}, Bio={Bio ?? "null"}, ProfilePic={ProfilePictureUrl ?? "null"}, DeletedAt={DeletedAt?.ToString() ?? "null"}]";
        }
    }
}
