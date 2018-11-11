using CM.Services.Wallet.Contract.Application.Events.Integration;
using CM.Shared.Kernel.Application.Base;
using Sieve.Attributes;

namespace CM.Services.Wallet.Contract.Domain.Models
{
    public class User : AggregateRoot
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public string Username { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Email { get; set; }

        public User()
        {
            Register<UserCreatedIntegrationEvent>(When);
            Register<UserUpdatedIntegrationEvent>(When);
            Register<UserDeletedIntegrationEvent>(When);
        }

        public static User Create()
        {
            return new User();
        }

        public void Start(string username, string email)
        {
            Raise(UserCreatedIntegrationEvent.Create(this, username, email));
        }

        public void UpdateUsername(string username)
        {
            Raise(UserUpdatedIntegrationEvent.Create(this, username, Email));
        }

        public void UpdateEmail(string email)
        {
            Raise(UserUpdatedIntegrationEvent.Create(this, Username, email));
        }

        public void Delete(string email)
        {
            Raise(UserDeletedIntegrationEvent.Create(this));
        }

        protected void When(UserCreatedIntegrationEvent @event)
        {
            Id = @event.AggregateRootId;
        }

        protected void When(UserUpdatedIntegrationEvent @event)
        {
            Id = @event.AggregateRootId;
            Username = @event.Username;
            Email = @event.Email;
        }

        protected void When(UserDeletedIntegrationEvent @event)
        {
            Id = @event.AggregateRootId;
        }
    }
}
