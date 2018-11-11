using CM.Services.Wallet.Contract.Domain.Models;
using CM.Shared.Kernel.Application.Bus.Models.Events;

namespace CM.Services.Wallet.Contract.Application.Events
{
    public class UserCreatedEvent : Event
    {
        public User User { get; set; }

        public Header Header { get; set; }
    }
}