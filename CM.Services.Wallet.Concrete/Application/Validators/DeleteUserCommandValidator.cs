
using CM.Services.Wallet.Contract.Application.Commands;
using FluentValidation;

namespace CM.Services.Wallet.Concrete.Application.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(cmd => cmd.Id)
                .NotEmpty();
                //.Must(userService.IsUsernameUnique);
        }
    }
}
