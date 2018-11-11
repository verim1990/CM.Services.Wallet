using CM.Services.Wallet.Contract.Application.Commands;
using CM.Services.Wallet.Contract.Application.Commands.Responses;
using CM.Services.Wallet.Contract.Application.Events;
using CM.Services.Wallet.Contract.Domain.Models;
using CM.Services.Wallet.Contract.Domain.Services;
using CM.Shared.Kernel.Application.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Application.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IBus Bus;
        private readonly IUserService UserService;

        public CreateUserCommandHandler(IBus bus, IUserService userService)
        {
            UserService = userService;
            Bus = bus;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken token)
        {
            var user = User.Create();

            user.Start(command.Username, command.Email);

            await UserService.CreateUser(user, token);
            await Bus.Publish(new UserCreatedEvent()
            {
                User = user,
                Header = command.Header
            });

            return new CreateUserResponse()
            {
                Id = user.Id
            };
        }
    }
}