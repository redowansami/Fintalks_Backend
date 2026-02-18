using Fintalks.Common.Commands;
using Fintalks.Common.Constants;
using FluentValidation;

namespace Fintalks.Api.Validator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(updateUser => updateUser.Name)
                .MinimumLength(UserConst.Length.minName)
                .MaximumLength(UserConst.Length.maxName);
            RuleFor(updateUser => updateUser.Bio).MaximumLength(UserConst.Length.maxBio);
        }
    }
}
