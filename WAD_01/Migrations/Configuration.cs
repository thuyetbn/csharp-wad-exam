namespace WAD_01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WAD_01.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WAD_01.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WAD_01.ApplicationDbContext";
        }

        protected override void Seed(WAD_01.Models.ApplicationDbContext context)
        {
            context.CustomerTypes.AddOrUpdate(x => x.TypeId,
                new CustomerType()
                {
                    TypeId = 1,
                    TypeName = "VIP",
                },
                new CustomerType()
                {
                    TypeId = 2,
                    TypeName = "Normal",
                }
            );
            context.Customers.AddOrUpdate(x => x.Id,
                new Customer()
                {
                    Id = "C0001",
                    FullName = "Nguyen Van A",
                    Address = "HCM",
                    Phone = "0973086596",
                    Gender = true,
                    TypeId = 1,
                },
                new Customer()
                {
                    Id = "C0002",
                    FullName = "Nguyen Van B",
                    Address = "HCM",
                    Phone = "0973086591",
                    Gender = false,
                    TypeId = 2,
                },
                new Customer()
                {
                    Id = "C0003",
                    FullName = "Nguyen Van C",
                    Address = "HN",
                    Phone = "0973086592",
                    Gender = false,
                    TypeId = 2,
                },
                new Customer()
                {
                    Id = "C0004",
                    FullName = "Nguyen Van D",
                    Address = "HN",
                    Phone = "0973086593",
                    Gender = false,
                    TypeId = 1,
                }
            );
        }
    }
}
