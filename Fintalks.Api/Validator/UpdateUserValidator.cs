using Fintalks.Common.Commands;
using FluentValidation;

namespace Fintalks.Api.Validator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(updateUser => updateUser.Name).MinimumLength(3).MaximumLength(20);
            RuleFor(updateUser => updateUser.Bio).MaximumLength(500);
        }
    }
}
