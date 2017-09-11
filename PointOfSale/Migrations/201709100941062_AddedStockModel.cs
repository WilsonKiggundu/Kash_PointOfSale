namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WebId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        UserId = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Products", t => t.Id)
                .ForeignKey("Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.Id)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Stocks", "UserId", "Users");
            DropForeignKey("Stocks", "TenantId", "Tenants");
            DropForeignKey("Stocks", "Id", "Products");
            DropIndex("Stocks", new[] { "UserId" });
            DropIndex("Stocks", new[] { "TenantId" });
            DropIndex("Stocks", new[] { "Id" });
            DropTable("Stocks");
        }
    }
}
