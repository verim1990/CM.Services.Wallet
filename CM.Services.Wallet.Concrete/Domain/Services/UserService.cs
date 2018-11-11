using CM.Services.Wallet.Contract.Domain.Models;
using CM.Services.Wallet.Contract.Domain.Services;
using CM.Services.Wallet.Infrastracture.Repositories;
using CM.Shared.Kernel.Application.Interfaces;
using CM.Shared.Kernel.Application.Interfaces.Repository;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository userRepository;
        private readonly SieveProcessor sieveProcessor;

        public UserService(UserRepository userRepository, SieveProcessor sieveProcessor)
        {
            this.userRepository = userRepository;
            this.sieveProcessor = sieveProcessor;
        }

        public async Task<User> GetUser(Guid id, CancellationToken token)
        {
            return await userRepository.GetAsync(id);
        }

        public async Task<Tuple<IEnumerable<User>, long>> GetUsers(SieveModel model, CancellationToken token)
        {
            var entities = userRepository.Users.AsQueryable();

            entities = sieveProcessor.Apply(model, entities, applyPagination: false);

            var total = entities.Count();

            entities = sieveProcessor.Apply(model, entities, applyFiltering: false, applySorting: false);

            return new Tuple<IEnumerable<User>, long>(await entities.ToAsyncEnumerable().ToList(), total);
        }

        public async Task CreateUser(User user, CancellationToken token)
        {
            await userRepository.InsertAsync(user, token);
            await userRepository.SaveChangesAsync();
        }
        public async Task UpdateUser(User user, CancellationToken token)
        {
            await userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(User user, CancellationToken token)
        {
            await userRepository.DeleteAsync(user, token);
            await userRepository.SaveChangesAsync();
        }
    }
}