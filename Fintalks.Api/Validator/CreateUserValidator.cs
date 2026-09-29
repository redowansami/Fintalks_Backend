using Fintalks.Common.Commands;
using Fintalks.Common.Constants;
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
                .WithMessage(UserConst.Message.invalidEmail);
            RuleFor(createUser => createUser.UserName)
                .NotEmpty()
                .MinimumLength(UserConst.Length.minUserName)
                .MaximumLength(UserConst.Length.maxUserName)
                .Matches("^[a-zA-Z0-9_]+$");
            RuleFor(createUser => createUser.Name)
                .NotEmpty()
                .MinimumLength(UserConst.Length.minName)
                .MaximumLength(UserConst.Length.maxName);
        }
    }
}
