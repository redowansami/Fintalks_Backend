using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Common.Commands
{
    public class UpdateUserProfileCommand
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
