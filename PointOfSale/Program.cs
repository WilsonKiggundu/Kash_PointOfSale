using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.Entity;
using PointOfSale.Forms;
using PointOfSale.Forms.Accounts;
using PointOfSale.Forms.Invoices;
using PointOfSale.Forms.Products;
using PointOfSale.Forms.Settings.Company;
using PointOfSale.Forms.Settings.Currency;
using PointOfSale.Forms.Settings.Tax;
using PointOfSale.Forms.Tenants;
using PointOfSale.Forms.User;

namespace PointOfSale
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var db = new PointOfSaleContext())
            {
                var tenants = db.Tenants.Where(q => q.Active).ToList();
                if (tenants.Any())
                {
                    var tenantIds = tenants.Select(s => s.Id).ToList();
                    var users = db.TenantUsers.Where(q => tenantIds.Contains(q.TenantId)).ToList();
                    if (users.Any())
                    {
                        Application.Run(new LoginForm());
                    }
                    else
                    {
                        Application.Run(new AddUserForm());
                    }
                }
                else
                {
                    Application.Run(new TenantCreateForm());
                }
            }
        }
    }
}
