using Fintalks.Common.Commands;
using Fintalks.Common.Constants;
using FluentValidation;

namespace Fintalks.Api.Validator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(registerUser => registerUser.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(UserConst.Message.invalidEmail);
            RuleFor(registerUser => registerUser.UserName)
                .NotEmpty()
                .MinimumLength(UserConst.Length.minUserName)
                .MaximumLength(UserConst.Length.maxUserName)
                .Matches("^[a-zA-Z0-9_]+$");
            RuleFor(registerUser => registerUser.Name)
                .NotEmpty()
                .MinimumLength(UserConst.Length.minName)
                .MaximumLength(UserConst.Length.maxName);
            RuleFor(registerUser => registerUser.Nid)
                .NotEmpty()
                .MinimumLength(UserConst.Length.minNid)
                .MaximumLength(UserConst.Length.maxNid);
            RuleFor(registerUser => registerUser.PhoneNumber)
                .NotEmpty()
                .Length(UserConst.Length.maxPhoneNumber);
            RuleFor(registerUser => registerUser.FatherName)
                .MinimumLength(UserConst.Length.minName)
                .MaximumLength(UserConst.Length.maxName);
            RuleFor(registerUser => registerUser.MotherName)
                .MinimumLength(UserConst.Length.minName)
                .MaximumLength(UserConst.Length.maxName);
        }
    }
}
