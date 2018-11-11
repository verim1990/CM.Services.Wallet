using CM.Services.Wallet.Contract.Domain.Models;
using CM.Services.Wallet.Infrastracture.Contexts;
using CM.Shared.Kernel.Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace CM.Services.Wallet.Infrastracture.Repositories
{
    public class UserRepository : EFRepository<User, ApplicationContext>
    {
        public DbSet<User> Users { get; set; }

        public UserRepository(ApplicationContext context) : base(context)
        {
            Users = context.Set<User>();
        }
    }
}
