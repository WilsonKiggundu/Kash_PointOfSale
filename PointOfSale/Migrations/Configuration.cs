using MySql.Data.Entity;
using PointOfSale.Models;

namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PointOfSale.PointOfSaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            // register mysql code generator
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }

        protected override void Seed(PointOfSale.PointOfSaleContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.AccessRights.AddOrUpdate(
                    r => r.Name,
                    new AccessRight { Name = "Login", Description = "User can login"},

                    // Users
                    new AccessRight { Name = "RegisterUsers", Description = "User can register users"},
                    new AccessRight { Name = "ViewUsers", Description = "User can view users"},
                    new AccessRight { Name = "ManageUsers", Description = "User can edit, delete, activate, deactivate users"},

                    // Products
                    new AccessRight { Name = "AddProducts", Description = "User can add new products"},
                    new AccessRight { Name = "ViewProducts", Description = "User can view products"},
                    new AccessRight { Name = "ManageProducts", Description = "User can edit, delete products" }
                );

            // context.SaveChanges();
        }
    }
}
