using CM.Services.Wallet.Contract.Application.Commands.Responses;
using System;

namespace CM.Services.Wallet.Contract.Application.Commands
{
    public class UpdateUserCommand : BaseUpsertUserCommand<UpdateUserResponse>
    {
        public Guid Id { get; set; }
    }
}