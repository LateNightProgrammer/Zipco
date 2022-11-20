using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.SeedData
{
    public class PopulateTestDataUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) {

            builder.HasData(
                new User
                {
                    Id= 1,
                    Name = "TestUser",
                    Email="TestData@test.com",
                    Income = 560.89M,
                    Expenses = 260.0M
                },
                new User
                {
                    Id= 2,
                    Name = "TestUser2",
                    Email = "TestData2@test.com",
                    Income = 760.89M,
                    Expenses = 250.0M
                });        
        }
    }
}
