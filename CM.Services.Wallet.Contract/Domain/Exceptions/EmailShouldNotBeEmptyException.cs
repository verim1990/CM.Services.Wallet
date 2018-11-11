using CM.Shared.Kernel.Application.Exceptions;

namespace CM.Services.Wallet.Contract.Domain.Exceptions
{
    public class EmailShouldNotBeEmptyException : DomainException
    {
        public EmailShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
