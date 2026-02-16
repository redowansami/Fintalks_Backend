using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.Common.Enums;

namespace Fintalks.Common.Commands
{
    public class UpdateUserCommand
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
