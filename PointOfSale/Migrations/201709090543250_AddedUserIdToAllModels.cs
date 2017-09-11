namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToAllModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GeneralJournals", "UserId", "Users");
            DropIndex("GeneralJournals", new[] { "UserId" });
            AddColumn("Accounts", "BalanceSheetCategory", c => c.Int(nullable: false));
            AddColumn("Accounts", "PurchaseAccountId", c => c.Int());
            AddColumn("Accounts", "UserId", c => c.Int());
            AddColumn("Currencies", "UserId", c => c.Int());
            AddColumn("Products", "UserId", c => c.Int());
            AddColumn("Taxes", "UserId", c => c.Int());
            AddColumn("Invoices", "UserId", c => c.Int());
            AddColumn("Memos", "UserId", c => c.Int());
            AddColumn("Receipts", "UserId", c => c.Int());
            AddColumn("Vouchers", "UserId", c => c.Int());
            AlterColumn("Accounts", "Category", c => c.Int(nullable: false));
            AlterColumn("Accounts", "CashflowCategory", c => c.Int(nullable: false));
            AlterColumn("GeneralJournals", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("GeneralJournals", "UserId", c => c.Int());
            AlterColumn("Invoices", "Paid", c => c.Boolean(nullable: false));
            CreateIndex("Accounts", "PurchaseAccountId");
            CreateIndex("Accounts", "TenantId");
            CreateIndex("Accounts", "UserId");
            CreateIndex("Currencies", "TenantId");
            CreateIndex("Currencies", "UserId");
            CreateIndex("GeneralJournals", "TenantId");
            CreateIndex("GeneralJournals", "UserId");
            CreateIndex("Products", "TenantId");
            CreateIndex("Products", "UserId");
            CreateIndex("Taxes", "TenantId");
            CreateIndex("Taxes", "UserId");
            CreateIndex("Invoices", "TaxId");
            CreateIndex("Invoices", "AccountId");
            CreateIndex("Invoices", "TenantId");
            CreateIndex("Invoices", "UserId");
            CreateIndex("Memos", "TenantId");
            CreateIndex("Memos", "UserId");
            CreateIndex("Receipts", "TenantId");
            CreateIndex("Receipts", "UserId");
            CreateIndex("Vouchers", "TenantId");
            CreateIndex("Vouchers", "UserId");
            AddForeignKey("Currencies", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Currencies", "UserId", "Users", "Id");
            AddForeignKey("Accounts", "PurchaseAccountId", "Accounts", "Id");
            AddForeignKey("Accounts", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Accounts", "UserId", "Users", "Id");
            AddForeignKey("Products", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Products", "UserId", "Users", "Id");
            AddForeignKey("Taxes", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Taxes", "UserId", "Users", "Id");
            AddForeignKey("GeneralJournals", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Invoices", "AccountId", "Accounts", "Id");
            AddForeignKey("Invoices", "TaxId", "Taxes", "Id");
            AddForeignKey("Invoices", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Invoices", "UserId", "Users", "Id");
            AddForeignKey("Memos", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Memos", "UserId", "Users", "Id");
            AddForeignKey("Receipts", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Receipts", "UserId", "Users", "Id");
            AddForeignKey("Vouchers", "TenantId", "Tenants", "Id", cascadeDelete: true);
            AddForeignKey("Vouchers", "UserId", "Users", "Id");
            AddForeignKey("GeneralJournals", "UserId", "Users", "Id");
            DropColumn("Accounts", "PurchaseAccount");
            DropColumn("Accounts", "BalanceSheetCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("Accounts", "BalanceSheetCategoryId", c => c.Int(nullable: false));
            AddColumn("Accounts", "PurchaseAccount", c => c.Int(nullable: false));
            DropForeignKey("GeneralJournals", "UserId", "Users");
            DropForeignKey("Vouchers", "UserId", "Users");
            DropForeignKey("Vouchers", "TenantId", "Tenants");
            DropForeignKey("Receipts", "UserId", "Users");
            DropForeignKey("Receipts", "TenantId", "Tenants");
            DropForeignKey("Memos", "UserId", "Users");
            DropForeignKey("Memos", "TenantId", "Tenants");
            DropForeignKey("Invoices", "UserId", "Users");
            DropForeignKey("Invoices", "TenantId", "Tenants");
            DropForeignKey("Invoices", "TaxId", "Taxes");
            DropForeignKey("Invoices", "AccountId", "Accounts");
            DropForeignKey("GeneralJournals", "TenantId", "Tenants");
            DropForeignKey("Taxes", "UserId", "Users");
            DropForeignKey("Taxes", "TenantId", "Tenants");
            DropForeignKey("Products", "UserId", "Users");
            DropForeignKey("Products", "TenantId", "Tenants");
            DropForeignKey("Accounts", "UserId", "Users");
            DropForeignKey("Accounts", "TenantId", "Tenants");
            DropForeignKey("Accounts", "PurchaseAccountId", "Accounts");
            DropForeignKey("Currencies", "UserId", "Users");
            DropForeignKey("Currencies", "TenantId", "Tenants");
            DropIndex("Vouchers", new[] { "UserId" });
            DropIndex("Vouchers", new[] { "TenantId" });
            DropIndex("Receipts", new[] { "UserId" });
            DropIndex("Receipts", new[] { "TenantId" });
            DropIndex("Memos", new[] { "UserId" });
            DropIndex("Memos", new[] { "TenantId" });
            DropIndex("Invoices", new[] { "UserId" });
            DropIndex("Invoices", new[] { "TenantId" });
            DropIndex("Invoices", new[] { "AccountId" });
            DropIndex("Invoices", new[] { "TaxId" });
            DropIndex("Taxes", new[] { "UserId" });
            DropIndex("Taxes", new[] { "TenantId" });
            DropIndex("Products", new[] { "UserId" });
            DropIndex("Products", new[] { "TenantId" });
            DropIndex("GeneralJournals", new[] { "UserId" });
            DropIndex("GeneralJournals", new[] { "TenantId" });
            DropIndex("Currencies", new[] { "UserId" });
            DropIndex("Currencies", new[] { "TenantId" });
            DropIndex("Accounts", new[] { "UserId" });
            DropIndex("Accounts", new[] { "TenantId" });
            DropIndex("Accounts", new[] { "PurchaseAccountId" });
            AlterColumn("Invoices", "Paid", c => c.Int(nullable: false));
            AlterColumn("GeneralJournals", "UserId", c => c.Int(nullable: false));
            AlterColumn("GeneralJournals", "ExchangeRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("Accounts", "CashflowCategory", c => c.String(unicode: false));
            AlterColumn("Accounts", "Category", c => c.String(unicode: false));
            DropColumn("Vouchers", "UserId");
            DropColumn("Receipts", "UserId");
            DropColumn("Memos", "UserId");
            DropColumn("Invoices", "UserId");
            DropColumn("Taxes", "UserId");
            DropColumn("Products", "UserId");
            DropColumn("Currencies", "UserId");
            DropColumn("Accounts", "UserId");
            DropColumn("Accounts", "PurchaseAccountId");
            DropColumn("Accounts", "BalanceSheetCategory");
            CreateIndex("GeneralJournals", "UserId");
            AddForeignKey("GeneralJournals", "UserId", "Users", "Id", cascadeDelete: true);
        }
    }
}
