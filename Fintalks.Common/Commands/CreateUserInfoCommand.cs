using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Models;

namespace Fintalks.Common.Commands
{
    public class CreateUserInfoCommand
    {
        public required int DBUserID { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public required string Nid { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
