using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Common.Commands
{
    public class RegisterUserCommand
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public required string Nid { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
