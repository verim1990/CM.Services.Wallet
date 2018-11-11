using CM.Services.Wallet.Contract.Domain.Models;
using CM.Services.Wallet.Infrastracture.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Services.Wallet.Infrastracture.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.ToTable(TableNames.User, SchemaNames.Wallet);
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Username);
            entityBuilder.Property(u => u.Email);
        }
    }
}