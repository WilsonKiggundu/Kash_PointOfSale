using System.Data.Entity;
using MySql.Data.Entity;
using PointOfSale.Models;

namespace PointOfSale
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PointOfSaleContext : DbContext
    {
        public PointOfSaleContext(): base("PointOfSaleContext")
        {
            Database.SetInitializer<PointOfSaleContext>(new CreateDatabaseIfNotExists<PointOfSaleContext>());
        }

        public static PointOfSaleContext Create()
        {
            return new PointOfSaleContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = true;

            modelBuilder.Entity<Currency>().Property(x => x.Rate).HasPrecision(18, 6);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.ParentAccount)
                .WithMany()
                .HasForeignKey(m => m.ParentAccountId);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.PurchaseAccount)
                .WithMany()
                .HasForeignKey(m => m.PurchaseAccountId);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<GeneralJournal> GeneralJournals { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Memo> Memos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<TenantUser> TenantUsers { get; set; }  
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<UserAccessRight> UserAccessRights { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockItem> StockItems { get; set; }    
        public DbSet<Location> Locations { get; set; }
    }
}
