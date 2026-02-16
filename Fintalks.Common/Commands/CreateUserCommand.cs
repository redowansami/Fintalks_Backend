using System;
using System.Collections.Generic;
using System.Text;

namespace Fintalks.Common.Commands
{
    public class CreateUserCommand
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"CreateUserCommand [UserName={UserName}, Name={Name}, Email={Email}]";
        }
    }
}
