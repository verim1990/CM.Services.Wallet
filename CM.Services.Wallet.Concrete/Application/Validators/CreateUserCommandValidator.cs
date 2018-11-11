using CM.Services.Wallet.Contract.Application.Commands;
using FluentValidation;

namespace CM.Services.Wallet.Concrete.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(cmd => cmd.Username)
                .NotEmpty()
                .MinimumLength(5);
                //.Must(userService.IsUsernameUnique);

            RuleFor(cmd => cmd.Email)
                .NotEmpty()
                .EmailAddress();
                //.Must(userService.IsEmailUnique);
        }
    }
}
