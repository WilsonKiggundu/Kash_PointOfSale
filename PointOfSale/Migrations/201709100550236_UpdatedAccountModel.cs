namespace PointOfSale.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAccountModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Accounts", "CurrencyId", "Currencies");
            DropIndex("Accounts", new[] { "CurrencyId" });
            AlterColumn("Accounts", "Fees", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("Accounts", "Depreciation", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("Accounts", "Budget", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("Accounts", "Category", c => c.Int());
            AlterColumn("Accounts", "CashflowCategory", c => c.Int());
            AlterColumn("Accounts", "BalanceSheetCategory", c => c.Int());
            AlterColumn("Accounts", "CurrencyId", c => c.Int());
            CreateIndex("Accounts", "CurrencyId");
            AddForeignKey("Accounts", "CurrencyId", "Currencies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Accounts", "CurrencyId", "Currencies");
            DropIndex("Accounts", new[] { "CurrencyId" });
            AlterColumn("Accounts", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Accounts", "BalanceSheetCategory", c => c.Int(nullable: false));
            AlterColumn("Accounts", "CashflowCategory", c => c.Int(nullable: false));
            AlterColumn("Accounts", "Category", c => c.Int(nullable: false));
            AlterColumn("Accounts", "Budget", c => c.Int(nullable: false));
            AlterColumn("Accounts", "Depreciation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("Accounts", "Fees", c => c.Int(nullable: false));
            CreateIndex("Accounts", "CurrencyId");
            AddForeignKey("Accounts", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
        }
    }
}
