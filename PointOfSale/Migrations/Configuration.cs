using MySql.Data.Entity;
using PointOfSale.Helpers;
using PointOfSale.Models;

namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PointOfSaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;

            // register mysql code generator
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }

        protected override void Seed(PointOfSaleContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Tenants.AddOrUpdate(
                r => r.Id,
                new Tenant { Id = 1, Name = "Eygo Ltd", Category = TenantCategory.General, Active = true }
            );

            context.Users.AddOrUpdate(
                r => r.Id,
                new User { Id = 1, FirstName = "System", LastName = "Administrator", Username = "administrator", Password = Encryption.GetMd5Hash("sw33th0m3") }
            );

            context.TenantUsers.AddOrUpdate(r => r.Id,
                new TenantUser { Id = 1, TenantId = 1, UserId = 1 }
            );

            context.Accounts.AddOrUpdate(
                r => r.Name,
                new Account { Name = "Accounts Receivable", DateCreated = DateTime.Now, TenantId = 1, UserId = 1},
                new Account { Name = "Accounts Payable", DateCreated = DateTime.Now, TenantId = 1, UserId = 1 },
                new Account { Name = "Cash Account", DateCreated = DateTime.Now, TenantId = 1, UserId = 1 }
            );
            
            context.SaveChanges();
        }
    }
}
