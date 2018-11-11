using CM.Shared.Kernel.Application.Base;
using CM.Shared.Kernel.Application.Bus.Models;
using CM.Shared.Kernel.Application.Bus.Models.Events;
using System;

namespace CM.Services.Wallet.Contract.Application.Events.Integration
{
    public class UserDeletedIntegrationEvent : IntegrationEvent
    {
        public UserDeletedIntegrationEvent(Guid aggregateRootId, int version, DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
            
        }

        public static UserDeletedIntegrationEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            var domainEvent = new UserDeletedIntegrationEvent(aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}