using CustomerWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerWebAPI.Seeder
{
    public class SeedData: IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Kehinde Enigbokan",
                    Email = "kehinde.enigbokan@wemabank.com",
                    Phone = 7053201384,
                    ImageUrl = "/Images/Beauty/Beauty1.png"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Hassan Daranijo",
                    Email = "hasan.daranijo@wemabank.com",
                    Phone = 8168301935,
                    ImageUrl = "/Images/Beauty/Beauty2.png"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Tosin Peters",
                    Email = "tosin.peters@wemabank.com",
                    Phone = 8053518772,
                    ImageUrl = "/Images/Beauty/Beauty3.png"
                }

            );
        } 
    }
}
