namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AccessRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        ParentAccountId = c.Int(),
                        Budget = c.Int(nullable: false),
                        PurchaseAccount = c.Int(nullable: false),
                        Fees = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        BalanceSheetCategoryId = c.Int(nullable: false),
                        Depreciation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(unicode: false),
                        CashflowCategory = c.String(unicode: false),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("Accounts", t => t.ParentAccountId)
                .Index(t => t.ParentAccountId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "GeneralJournals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        Category = c.String(unicode: false),
                        ProductId = c.Int(),
                        CreditAccountId = c.Int(),
                        DebitAccountId = c.Int(),
                        VoucherId = c.Int(),
                        MemoId = c.Int(),
                        ReceiptId = c.Int(),
                        InvoiceId = c.Int(),
                        Particulars = c.String(unicode: false),
                        BankId = c.Int(),
                        TaxId = c.Int(),
                        ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        Term = c.String(unicode: false),
                        Form = c.String(unicode: false),
                        Year = c.Int(),
                        ReferenceNumber = c.String(unicode: false),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Products", t => t.ProductId)
                .ForeignKey("Taxes", t => t.TaxId)
                .ForeignKey("Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TaxId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostPrice = c.Decimal(precision: 18, scale: 2),
                        SellPrice = c.Decimal(precision: 18, scale: 2),
                        Barcode = c.String(unicode: false),
                        OpeningStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Code = c.String(unicode: false),
                        ProductType = c.String(unicode: false),
                        MinStock = c.Decimal(precision: 18, scale: 2),
                        MaxStock = c.Decimal(precision: 18, scale: 2),
                        Sale = c.Int(nullable: false),
                        SaleAccountId = c.Int(nullable: false),
                        Purchase = c.Int(nullable: false),
                        PurchaseAccountId = c.Int(nullable: false),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Taxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Percentage = c.Decimal(precision: 18, scale: 2),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Username = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        LastLoggedIn = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "UserAccessRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessRightId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AccessRights", t => t.AccessRightId, cascadeDelete: true)
                .ForeignKey("Users", t => t.User_Id)
                .Index(t => t.AccessRightId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        InvoiceType = c.Int(nullable: false),
                        Remarks = c.String(unicode: false),
                        Paid = c.Int(nullable: false),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        Number = c.String(unicode: false),
                        TaxId = c.Int(),
                        AccountId = c.Int(),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "Memos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        InvoiceType = c.Int(nullable: false),
                        Remarks = c.String(unicode: false),
                        Paid = c.Int(nullable: false),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        InvoiceNumber = c.String(unicode: false),
                        TaxId = c.Int(),
                        AccountId = c.Int(),
                        InvoiceId = c.Int(),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Accounts", t => t.AccountId)
                .ForeignKey("Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("Invoices", t => t.InvoiceId)
                .Index(t => t.CurrencyId)
                .Index(t => t.AccountId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        InvoiceType = c.Int(nullable: false),
                        Remarks = c.String(unicode: false),
                        Paid = c.Int(nullable: false),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        InvoiceNumber = c.String(unicode: false),
                        TaxId = c.Int(),
                        AccountId = c.Int(),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "Tenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Category = c.String(unicode: false),
                        Active = c.Int(nullable: false),
                        LastPaymentDate = c.DateTime(precision: 0),
                        Telephone = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        PostalAddress = c.String(unicode: false),
                        Logo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "TenantUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        InvoiceType = c.Int(nullable: false),
                        Remarks = c.String(unicode: false),
                        Paid = c.Int(nullable: false),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        Number = c.String(unicode: false),
                        TaxId = c.Int(),
                        AccountId = c.Int(),
                        InvoiceId = c.Int(),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Vouchers", "CurrencyId", "Currencies");
            DropForeignKey("TenantUsers", "UserId", "Users");
            DropForeignKey("TenantUsers", "TenantId", "Tenants");
            DropForeignKey("Receipts", "CurrencyId", "Currencies");
            DropForeignKey("Memos", "InvoiceId", "Invoices");
            DropForeignKey("Memos", "CurrencyId", "Currencies");
            DropForeignKey("Memos", "AccountId", "Accounts");
            DropForeignKey("Invoices", "CurrencyId", "Currencies");
            DropForeignKey("GeneralJournals", "UserId", "Users");
            DropForeignKey("UserAccessRights", "User_Id", "Users");
            DropForeignKey("UserAccessRights", "AccessRightId", "AccessRights");
            DropForeignKey("GeneralJournals", "TaxId", "Taxes");
            DropForeignKey("GeneralJournals", "ProductId", "Products");
            DropForeignKey("Accounts", "ParentAccountId", "Accounts");
            DropForeignKey("Accounts", "CurrencyId", "Currencies");
            DropIndex("Vouchers", new[] { "CurrencyId" });
            DropIndex("TenantUsers", new[] { "UserId" });
            DropIndex("TenantUsers", new[] { "TenantId" });
            DropIndex("Receipts", new[] { "CurrencyId" });
            DropIndex("Memos", new[] { "InvoiceId" });
            DropIndex("Memos", new[] { "AccountId" });
            DropIndex("Memos", new[] { "CurrencyId" });
            DropIndex("Invoices", new[] { "CurrencyId" });
            DropIndex("UserAccessRights", new[] { "User_Id" });
            DropIndex("UserAccessRights", new[] { "AccessRightId" });
            DropIndex("GeneralJournals", new[] { "UserId" });
            DropIndex("GeneralJournals", new[] { "TaxId" });
            DropIndex("GeneralJournals", new[] { "ProductId" });
            DropIndex("Accounts", new[] { "CurrencyId" });
            DropIndex("Accounts", new[] { "ParentAccountId" });
            DropTable("Vouchers");
            DropTable("TenantUsers");
            DropTable("Tenants");
            DropTable("Receipts");
            DropTable("Memos");
            DropTable("Invoices");
            DropTable("UserAccessRights");
            DropTable("Users");
            DropTable("Taxes");
            DropTable("Products");
            DropTable("GeneralJournals");
            DropTable("Currencies");
            DropTable("Accounts");
            DropTable("AccessRights");
        }
    }
}
