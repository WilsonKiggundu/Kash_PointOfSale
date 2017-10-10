namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Memos", "CurrencyId", "Currencies");
            DropForeignKey("Receipts", "CurrencyId", "Currencies");
            DropForeignKey("Vouchers", "CurrencyId", "Currencies");
            DropIndex("Memos", new[] { "CurrencyId" });
            DropIndex("Receipts", new[] { "CurrencyId" });
            DropIndex("Vouchers", new[] { "CurrencyId" });
            CreateTable(
                "Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        UserId = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        SourceId = c.Int(),
                        DestinationId = c.Int(),
                        Remarks = c.String(unicode: false),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        UserId = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Locations", t => t.DestinationId)
                .ForeignKey("Locations", t => t.SourceId)
                .ForeignKey("Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.SourceId)
                .Index(t => t.DestinationId)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
            CreateTable(
                "StockItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(unicode: false),
                        Category = c.Int(nullable: false),
                        Particulars = c.String(unicode: false),
                        StockId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(precision: 0),
                        ManufactureDate = c.DateTime(precision: 0),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        UserId = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Stocks", t => t.StockId, cascadeDelete: true)
                .ForeignKey("Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.StockId)
                .Index(t => t.ProductId)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
            AddColumn("Tenants", "WebId", c => c.Int());
            AddColumn("Tenants", "Tin", c => c.String(unicode: false));
            AddColumn("Invoices", "LocationId", c => c.Int());
            AddColumn("Memos", "Number", c => c.String(unicode: false));
            AddColumn("Receipts", "InvoiceId", c => c.Int());
            AddColumn("Receipts", "Number", c => c.String(unicode: false));
            AlterColumn("Currencies", "Rate", c => c.Decimal(precision: 18, scale: 6));
            AlterColumn("GeneralJournals", "Category", c => c.Int(nullable: false));
            AlterColumn("Memos", "CompanyId", c => c.Int());
            AlterColumn("Memos", "Paid", c => c.Boolean(nullable: false));
            AlterColumn("Memos", "CurrencyId", c => c.Int());
            AlterColumn("Receipts", "CompanyId", c => c.Int());
            AlterColumn("Receipts", "Paid", c => c.Boolean(nullable: false));
            AlterColumn("Receipts", "CurrencyId", c => c.Int());
            AlterColumn("Vouchers", "CompanyId", c => c.Int());
            AlterColumn("Vouchers", "Paid", c => c.Boolean(nullable: false));
            AlterColumn("Vouchers", "CurrencyId", c => c.Int());
            CreateIndex("Invoices", "LocationId");
            CreateIndex("Memos", "CurrencyId");
            CreateIndex("Memos", "TaxId");
            CreateIndex("Memos", "CompanyId");
            CreateIndex("Receipts", "InvoiceId");
            CreateIndex("Receipts", "CompanyId");
            CreateIndex("Receipts", "TaxId");
            CreateIndex("Receipts", "AccountId");
            CreateIndex("Receipts", "CurrencyId");
            CreateIndex("Vouchers", "CurrencyId");
            CreateIndex("Vouchers", "TaxId");
            CreateIndex("Vouchers", "AccountId");
            CreateIndex("Vouchers", "InvoiceId");
            CreateIndex("Vouchers", "CompanyId");
            AddForeignKey("Invoices", "LocationId", "Locations", "Id");
            AddForeignKey("Memos", "CompanyId", "Companies", "Id");
            AddForeignKey("Memos", "TaxId", "Taxes", "Id");
            AddForeignKey("Receipts", "AccountId", "Accounts", "Id");
            AddForeignKey("Receipts", "CompanyId", "Companies", "Id");
            AddForeignKey("Receipts", "InvoiceId", "Invoices", "Id");
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
            DropForeignKey("Stocks", "UserId", "Users");
            DropForeignKey("Stocks", "TenantId", "Tenants");
            DropForeignKey("StockItems", "UserId", "Users");
            DropForeignKey("StockItems", "TenantId", "Tenants");
            DropForeignKey("StockItems", "StockId", "Stocks");
            DropForeignKey("StockItems", "ProductId", "Products");
            DropForeignKey("Stocks", "SourceId", "Locations");
            DropForeignKey("Stocks", "DestinationId", "Locations");
            DropForeignKey("Vouchers", "TaxId", "Taxes");
            DropForeignKey("Vouchers", "InvoiceId", "Invoices");
            DropForeignKey("Vouchers", "CompanyId", "Companies");
            DropForeignKey("Vouchers", "AccountId", "Accounts");
            DropForeignKey("Receipts", "TaxId", "Taxes");
            DropForeignKey("Receipts", "InvoiceId", "Invoices");
            DropForeignKey("Receipts", "CompanyId", "Companies");
            DropForeignKey("Receipts", "AccountId", "Accounts");
            DropForeignKey("Memos", "TaxId", "Taxes");
            DropForeignKey("Memos", "CompanyId", "Companies");
            DropForeignKey("Invoices", "LocationId", "Locations");
            DropForeignKey("Locations", "UserId", "Users");
            DropForeignKey("Locations", "TenantId", "Tenants");
            DropIndex("StockItems", new[] { "UserId" });
            DropIndex("StockItems", new[] { "TenantId" });
            DropIndex("StockItems", new[] { "ProductId" });
            DropIndex("StockItems", new[] { "StockId" });
            DropIndex("Stocks", new[] { "UserId" });
            DropIndex("Stocks", new[] { "TenantId" });
            DropIndex("Stocks", new[] { "DestinationId" });
            DropIndex("Stocks", new[] { "SourceId" });
            DropIndex("Vouchers", new[] { "CompanyId" });
            DropIndex("Vouchers", new[] { "InvoiceId" });
            DropIndex("Vouchers", new[] { "AccountId" });
            DropIndex("Vouchers", new[] { "TaxId" });
            DropIndex("Vouchers", new[] { "CurrencyId" });
            DropIndex("Receipts", new[] { "CurrencyId" });
            DropIndex("Receipts", new[] { "AccountId" });
            DropIndex("Receipts", new[] { "TaxId" });
            DropIndex("Receipts", new[] { "CompanyId" });
            DropIndex("Receipts", new[] { "InvoiceId" });
            DropIndex("Memos", new[] { "CompanyId" });
            DropIndex("Memos", new[] { "TaxId" });
            DropIndex("Memos", new[] { "CurrencyId" });
            DropIndex("Locations", new[] { "UserId" });
            DropIndex("Locations", new[] { "TenantId" });
            DropIndex("Invoices", new[] { "LocationId" });
            AlterColumn("Vouchers", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Vouchers", "Paid", c => c.Int(nullable: false));
            AlterColumn("Vouchers", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("Receipts", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Receipts", "Paid", c => c.Int(nullable: false));
            AlterColumn("Receipts", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("Memos", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("Memos", "Paid", c => c.Int(nullable: false));
            AlterColumn("Memos", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("GeneralJournals", "Category", c => c.String(unicode: false));
            AlterColumn("Currencies", "Rate", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("Receipts", "Number");
            DropColumn("Receipts", "InvoiceId");
            DropColumn("Memos", "Number");
            DropColumn("Invoices", "LocationId");
            DropColumn("Tenants", "Tin");
            DropColumn("Tenants", "WebId");
            DropTable("StockItems");
            DropTable("Stocks");
            DropTable("Locations");
            CreateIndex("Vouchers", "CurrencyId");
            CreateIndex("Receipts", "CurrencyId");
            CreateIndex("Memos", "CurrencyId");
            AddForeignKey("Vouchers", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
            AddForeignKey("Receipts", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
            AddForeignKey("Memos", "CurrencyId", "Currencies", "Id", cascadeDelete: true);
        }
    }
}
