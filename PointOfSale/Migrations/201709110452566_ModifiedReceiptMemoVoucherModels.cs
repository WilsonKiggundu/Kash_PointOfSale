namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedReceiptMemoVoucherModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Memos", "CurrencyId", "Currencies");
            DropForeignKey("Receipts", "CurrencyId", "Currencies");
            DropForeignKey("Vouchers", "CurrencyId", "Currencies");
            DropIndex("Memos", new[] { "CurrencyId" });
            DropIndex("Receipts", new[] { "CurrencyId" });
            DropIndex("Vouchers", new[] { "CurrencyId" });
            AddColumn("Memos", "Number", c => c.String(unicode: false));
            AddColumn("Receipts", "Number", c => c.String(unicode: false));
            AlterColumn("Memos", "CompanyId", c => c.Int());
            AlterColumn("Memos", "Paid", c => c.Boolean(nullable: false));
            AlterColumn("Memos", "CurrencyId", c => c.Int());
            AlterColumn("Receipts", "CompanyId", c => c.Int());
            AlterColumn("Receipts", "Paid", c => c.Boolean(nullable: false));
            AlterColumn("Receipts", "CurrencyId", c => c.Int());
            AlterColumn("Vouchers", "CompanyId", c => c.Int());
            AlterColumn("Vouchers", "Paid", c => c.Boolean(nullable: false));
            AlterColumn("Vouchers", "CurrencyId", c => c.Int());
            CreateIndex("Memos", "CurrencyId");
            CreateIndex("Memos", "TaxId");
            CreateIndex("Memos", "CompanyId");
            CreateIndex("Receipts", "CompanyId");
            CreateIndex("Receipts", "TaxId");
            CreateIndex("Receipts", "AccountId");
            CreateIndex("Receipts", "CurrencyId");
            CreateIndex("Vouchers", "CurrencyId");
            CreateIndex("Vouchers", "TaxId");
            CreateIndex("Vouchers", "AccountId");
            CreateIndex("Vouchers", "InvoiceId");
            CreateIndex("Vouchers", "CompanyId");
            AddForeignKey("Memos", "CompanyId", "Companies", "Id");
            AddForeignKey("Memos", "TaxId", "Taxes", "Id");
            AddForeignKey("Receipts", "AccountId", "Accounts", "Id");
            AddForeignKey("Receipts", "CompanyId", "Companies", "Id");
            AddForeignKey("Receipts", "TaxId", "Taxes", "Id");
            AddForeignKey("Vouchers", "AccountId", "Accounts", "Id");
            AddForeignKey("Vouchers", "CompanyId", "Companies", "Id");
            AddForeignKey("Vouchers", "InvoiceId", "Invoices", "Id");
            AddForeignKey("Vouchers", "TaxId", "Taxes", "Id");
            AddForeignKey("Memos", "CurrencyId", "Currencies", "Id");
            AddForeignKey("Receipts", "CurrencyId", "Currencies", "Id");
            AddForeignKey("Vouchers", "CurrencyId", "Currencies", "Id");
            DropColumn("Memos", "InvoiceNumber");
            DropColumn("Receipts", "InvoiceNumber");
        }
        
        public override void Down()
        {
            AddColumn("Receipts", "InvoiceNumber", c => c.String(unicode: false));
            AddColumn("Memos", "InvoiceNumber", c => c.String(unicode: false));
            DropForeignKey("Vouchers", "CurrencyId", "Currencies");
            DropForeignKey("Receipts", "CurrencyId", "Currencies");
            DropForeignKey("Memos", "CurrencyId", "Currencies");
            DropForeignKey("Vouchers", "TaxId", "Taxes");
            DropForeignKey("Vouchers", "InvoiceId", "Invoices");
            DropForeignKey("Vouchers", "CompanyId", "Companies");
            DropForeignKey("Vouchers", "AccountId", "Accounts");
            DropForeignKey("Receipts", "TaxId", "Taxes");
            DropForeignKey("Receipts", "CompanyId", "Companies");
            DropForeignKey("Receipts", "AccountId", "Accounts");
            DropForeignKey("Memos", "TaxId", "Taxes");
            DropForeignKey("Memos", "CompanyId", "Companies");
            DropIndex("Vouchers", new[] { "CompanyId" });
            DropIndex("Vouchers", new[] { "InvoiceId" });
            DropIndex("Vouchers", new[] { "AccountId" });
            DropIndex("Vouchers", new[] { "TaxId" });
            DropIndex("Vouchers", new[] { "CurrencyId" });
            DropIndex("Receipts", new[] { "CurrencyId" });
            DropIndex("Receipts", new[] { "AccountId" });
            DropIndex("Receipts", new[] { "TaxId" });
            DropIndex("Receipts", new[] { "CompanyId" });
            DropIndex("Memos", new[] { "CompanyId" });
            DropIndex("Memos", new[] { "TaxId" });
            DropIndex("Memos", new[] { "CurrencyId" });
            AlterColumn("Vouchers", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Vouchers", "Paid", c => c.Int(nullable: false));
            AlterColumn("Vouchers", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("Receipts", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Receipts", "Paid", c => c.Int(nullable: false));
            AlterColumn("Receipts", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("Memos", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Memos", "Paid", c => c.Int(nullable: false));
            AlterColumn("Memos", "CompanyId", c => c.Int(nullable: false));
            DropColumn("Receipts", "Number");
            DropColumn("Memos", "Number");
            CreateIndex("Vouchers", "CurrencyId");
            CreateIndex("Receipts", "CurrencyId");
            CreateIndex("Memos", "CurrencyId");
            AddForeignKey("Vouchers", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
            AddForeignKey("Receipts", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
            AddForeignKey("Memos", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
        }
    }
}
