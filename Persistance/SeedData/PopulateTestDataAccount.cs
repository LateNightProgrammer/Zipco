using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.SeedData
{
    public class PopulateTestDataAccount : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    Id =   1,
                    UserId = 1
                },
                new Account
                {
                    Id = 2,
                    UserId = 2
                });
        }
    }
}
