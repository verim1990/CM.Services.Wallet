using CM.Services.Wallet.Contract.Application.Commands.Responses;
using CM.Shared.Kernel.Application.Bus.Models.Commands;

namespace CM.Services.Wallet.Contract.Application.Commands
{
    public class BaseUpsertUserCommand<T> : CommandWithResponse<T> where T : CommandResponse
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }

    public class CreateUserCommand : BaseUpsertUserCommand<CreateUserResponse>
    {

    }
}