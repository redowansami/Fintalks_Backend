namespace Fintalks.Common.Commands
{
    public class CreateUserCommand
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public override string ToString()
        {
            return $"CreateUserCommand [UserName={UserName}, Name={Name}, Email={Email}]";
        }
    }
}
