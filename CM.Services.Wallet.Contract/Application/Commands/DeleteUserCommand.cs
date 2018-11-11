using CM.Services.Wallet.Contract.Application.Commands.Responses;
using CM.Shared.Kernel.Application.Bus.Models.Commands;
using System;

namespace CM.Services.Wallet.Contract.Application.Commands
{
    public class DeleteUserCommand : CommandWithResponse<DeleteUserResponse>
    {
        public Guid Id { get; set; }
    }
}