using CM.Services.Wallet.Contract.Domain.Models;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Contract.Domain.Services
{
    public interface IUserService
    {
        Task CreateUser(User user, CancellationToken token);

        Task DeleteUser(User user, CancellationToken token);

        Task UpdateUser(User user, CancellationToken token);

        Task<User> GetUser(Guid id, CancellationToken token);

        Task<Tuple<IEnumerable<User>, long>> GetUsers(SieveModel model, CancellationToken token);
    }
}