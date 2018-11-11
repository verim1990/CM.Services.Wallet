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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IBus Bus;
        private readonly IUserService UserService;

        public DeleteUserCommandHandler(IBus bus, IUserService userService)
        {
            UserService = userService;
            Bus = bus;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand command, CancellationToken token)
        {
            var user = await UserService.GetUser(command.Id, token);

            await UserService.DeleteUser(user, token);
            await Bus.Publish(new UserDeletedEvent()
            {
                User = user,
                Header = command.Header
            });

            return new DeleteUserResponse();
        }
    }
}