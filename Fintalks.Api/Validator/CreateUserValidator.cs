using Fintalks.Common.Commands;
using FluentValidation;

namespace Fintalks.Api.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(createUser => createUser.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email format.");
            RuleFor(createUser => createUser.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(10)
                .Matches("^[a-zA-Z0-9_]+$");
            RuleFor(createUser => createUser.Name).NotEmpty().MinimumLength(3).MaximumLength(25);
        }
    }
}
