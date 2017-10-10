namespace PointOfSale.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedInvoiceModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Invoices", "CurrencyId", "Currencies");
            DropIndex("Invoices", new[] { "CurrencyId" });
            AlterColumn("Currencies", "Rate", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("Invoices", "CurrencyId", c => c.Int());
            CreateIndex("Invoices", "CurrencyId");
            AddForeignKey("Invoices", "CurrencyId", "Currencies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Invoices", "CurrencyId", "Currencies");
            DropIndex("Invoices", new[] { "CurrencyId" });
            AlterColumn("Invoices", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Currencies", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("Invoices", "CurrencyId");
            AddForeignKey("Invoices", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
        }
    }
}
