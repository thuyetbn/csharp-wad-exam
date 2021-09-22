using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WAD_01.Migrations;

namespace WAD_01.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}