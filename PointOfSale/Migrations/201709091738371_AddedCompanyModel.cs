namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompanyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Telephone = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        CurrencyId = c.Int(),
                        Landlord = c.Boolean(nullable: false),
                        Occupant = c.Boolean(nullable: false),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        UserId = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Currencies", t => t.CurrencyId)
                .ForeignKey("Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.CurrencyId)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
            AlterColumn("GeneralJournals", "CompanyId", c => c.Int());
            AlterColumn("Invoices", "CompanyId", c => c.Int());
            CreateIndex("GeneralJournals", "CompanyId");
            CreateIndex("GeneralJournals", "CreditAccountId");
            CreateIndex("GeneralJournals", "DebitAccountId");
            CreateIndex("GeneralJournals", "VoucherId");
            CreateIndex("GeneralJournals", "MemoId");
            CreateIndex("GeneralJournals", "ReceiptId");
            CreateIndex("GeneralJournals", "InvoiceId");
            CreateIndex("Invoices", "CompanyId");
            AddForeignKey("GeneralJournals", "CompanyId", "Companies", "Id");
            AddForeignKey("GeneralJournals", "CreditAccountId", "Accounts", "Id");
            AddForeignKey("GeneralJournals", "DebitAccountId", "Accounts", "Id");
            AddForeignKey("Invoices", "CompanyId", "Companies", "Id");
            AddForeignKey("GeneralJournals", "InvoiceId", "Invoices", "Id");
            AddForeignKey("GeneralJournals", "MemoId", "Memos", "Id");
            AddForeignKey("GeneralJournals", "ReceiptId", "Receipts", "Id");
            AddForeignKey("GeneralJournals", "VoucherId", "Vouchers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("GeneralJournals", "VoucherId", "Vouchers");
            DropForeignKey("GeneralJournals", "ReceiptId", "Receipts");
            DropForeignKey("GeneralJournals", "MemoId", "Memos");
            DropForeignKey("GeneralJournals", "InvoiceId", "Invoices");
            DropForeignKey("Invoices", "CompanyId", "Companies");
            DropForeignKey("GeneralJournals", "DebitAccountId", "Accounts");
            DropForeignKey("GeneralJournals", "CreditAccountId", "Accounts");
            DropForeignKey("GeneralJournals", "CompanyId", "Companies");
            DropForeignKey("Companies", "UserId", "Users");
            DropForeignKey("Companies", "TenantId", "Tenants");
            DropForeignKey("Companies", "CurrencyId", "Currencies");
            DropIndex("Invoices", new[] { "CompanyId" });
            DropIndex("Companies", new[] { "UserId" });
            DropIndex("Companies", new[] { "TenantId" });
            DropIndex("Companies", new[] { "CurrencyId" });
            DropIndex("GeneralJournals", new[] { "InvoiceId" });
            DropIndex("GeneralJournals", new[] { "ReceiptId" });
            DropIndex("GeneralJournals", new[] { "MemoId" });
            DropIndex("GeneralJournals", new[] { "VoucherId" });
            DropIndex("GeneralJournals", new[] { "DebitAccountId" });
            DropIndex("GeneralJournals", new[] { "CreditAccountId" });
            DropIndex("GeneralJournals", new[] { "CompanyId" });
            AlterColumn("Invoices", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("GeneralJournals", "CompanyId", c => c.Int(nullable: false));
            DropTable("Companies");
        }
    }
}
