using CM.Services.Wallet.Contract.Application.Commands;
using CM.Services.Wallet.Contract.Application.Commands.Responses;
using CM.Services.Wallet.Contract.Application.Events;
using CM.Services.Wallet.Contract.Domain.Services;
using CM.Shared.Kernel.Application.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Application.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IBus Bus;
        private readonly IUserService UserService;

        public UpdateUserCommandHandler(IBus bus, IUserService userService)
        {
            UserService = userService;
            Bus = bus;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand command, CancellationToken token)
        {
            var user = await UserService.GetUser(command.Id, token);

            user.UpdateEmail(command.Email);
            user.UpdateUsername(command.Username);

            await UserService.UpdateUser(user, token);
            await Bus.Publish(new UserUpdatedEvent()
            {
                User = user,
                Header = command.Header
            });

            return new UpdateUserResponse();
        }
    }
}