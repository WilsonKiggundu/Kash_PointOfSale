namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedProductModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("Memos", "Type", c => c.Int(nullable: false));
            AddColumn("Receipts", "Type", c => c.Int(nullable: false));
            AddColumn("Vouchers", "Type", c => c.Int(nullable: false));
            AlterColumn("Products", "ProductType", c => c.Int());
            AlterColumn("Products", "Sale", c => c.Boolean(nullable: false));
            AlterColumn("Products", "SaleAccountId", c => c.Int());
            AlterColumn("Products", "Purchase", c => c.Boolean(nullable: false));
            AlterColumn("Products", "PurchaseAccountId", c => c.Int());
            CreateIndex("Products", "SaleAccountId");
            CreateIndex("Products", "PurchaseAccountId");
            AddForeignKey("Products", "PurchaseAccountId", "Accounts", "Id");
            AddForeignKey("Products", "SaleAccountId", "Accounts", "Id");
            DropColumn("Memos", "InvoiceType");
            DropColumn("Receipts", "InvoiceType");
            DropColumn("Vouchers", "InvoiceType");
        }
        
        public override void Down()
        {
            AddColumn("Vouchers", "InvoiceType", c => c.Int(nullable: false));
            AddColumn("Receipts", "InvoiceType", c => c.Int(nullable: false));
            AddColumn("Memos", "InvoiceType", c => c.Int(nullable: false));
            DropForeignKey("Products", "SaleAccountId", "Accounts");
            DropForeignKey("Products", "PurchaseAccountId", "Accounts");
            DropIndex("Products", new[] { "PurchaseAccountId" });
            DropIndex("Products", new[] { "SaleAccountId" });
            AlterColumn("Products", "PurchaseAccountId", c => c.Int(nullable: false));
            AlterColumn("Products", "Purchase", c => c.Int(nullable: false));
            AlterColumn("Products", "SaleAccountId", c => c.Int(nullable: false));
            AlterColumn("Products", "Sale", c => c.Int(nullable: false));
            AlterColumn("Products", "ProductType", c => c.String(unicode: false));
            DropColumn("Vouchers", "Type");
            DropColumn("Receipts", "Type");
            DropColumn("Memos", "Type");
        }
    }
}
