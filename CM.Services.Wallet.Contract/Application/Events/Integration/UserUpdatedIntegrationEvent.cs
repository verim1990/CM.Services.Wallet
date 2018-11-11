using CM.Shared.Kernel.Application.Base;
using CM.Shared.Kernel.Application.Bus.Models;
using CM.Shared.Kernel.Application.Bus.Models.Events;
using System;

namespace CM.Services.Wallet.Contract.Application.Events.Integration
{
    public class UserUpdatedIntegrationEvent : IntegrationEvent
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public UserUpdatedIntegrationEvent(Guid aggregateRootId, int version, DateTime createdDate, Header header, string username, string email)
            : base(aggregateRootId, version, createdDate, header)
        {
            Username = username;
            Email = email;
        }

        public static UserUpdatedIntegrationEvent Create(AggregateRoot aggregateRoot, string username, string email)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            var domainEvent = new UserUpdatedIntegrationEvent(aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, username, email);

            return domainEvent;
        }
    }
}