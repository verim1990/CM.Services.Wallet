using CM.Shared.Kernel.Application.Bus.Models.Commands;
using System;

namespace CM.Services.Wallet.Contract.Application.Commands.Responses
{
    public class CreateUserResponse : CommandResponse
    {
        public Guid Id { get; set; }
    }
}