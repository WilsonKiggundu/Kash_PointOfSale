namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadePropertiesNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("StockItems", "StockId", "Stocks");
            DropForeignKey("StockItems", "ProductId", "Products");
            DropIndex("StockItems", new[] { "StockId" });
            DropIndex("StockItems", new[] { "ProductId" });
            AddColumn("StockItems", "SourceLocationId", c => c.Int());
            AddColumn("StockItems", "DestinationLocationId", c => c.Int());
            AlterColumn("StockItems", "Quantity", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("StockItems", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("StockItems", "StockId", c => c.Int());
            AlterColumn("StockItems", "ProductId", c => c.Int());
            CreateIndex("StockItems", "StockId");
            CreateIndex("StockItems", "ProductId");
            CreateIndex("StockItems", "SourceLocationId");
            CreateIndex("StockItems", "DestinationLocationId");
            AddForeignKey("StockItems", "DestinationLocationId", "Locations", "Id");
            AddForeignKey("StockItems", "SourceLocationId", "Locations", "Id");
            AddForeignKey("StockItems", "StockId", "Stocks", "Id");
            AddForeignKey("StockItems", "ProductId", "Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("StockItems", "ProductId", "Products");
            DropForeignKey("StockItems", "StockId", "Stocks");
            DropForeignKey("StockItems", "SourceLocationId", "Locations");
            DropForeignKey("StockItems", "DestinationLocationId", "Locations");
            DropIndex("StockItems", new[] { "DestinationLocationId" });
            DropIndex("StockItems", new[] { "SourceLocationId" });
            DropIndex("StockItems", new[] { "ProductId" });
            DropIndex("StockItems", new[] { "StockId" });
            AlterColumn("StockItems", "ProductId", c => c.Int(nullable: false));
            AlterColumn("StockItems", "StockId", c => c.Int(nullable: false));
            AlterColumn("StockItems", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("StockItems", "Quantity", c => c.Single(nullable: false));
            DropColumn("StockItems", "DestinationLocationId");
            DropColumn("StockItems", "SourceLocationId");
            CreateIndex("StockItems", "ProductId");
            CreateIndex("StockItems", "StockId");
            AddForeignKey("StockItems", "ProductId", "Products", "Id", cascadeDelete: true);
            AddForeignKey("StockItems", "StockId", "Stocks", "Id", cascadeDelete: true);
        }
    }
}
