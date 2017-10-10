namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationOnReceiptAndVoucherModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("Memos", "LocationId", c => c.Int());
            AddColumn("Receipts", "LocationId", c => c.Int());
            AddColumn("Vouchers", "LocationId", c => c.Int());
            CreateIndex("Memos", "LocationId");
            CreateIndex("Receipts", "LocationId");
            CreateIndex("Vouchers", "LocationId");
            AddForeignKey("Memos", "LocationId", "Locations", "Id");
            AddForeignKey("Receipts", "LocationId", "Locations", "Id");
            AddForeignKey("Vouchers", "LocationId", "Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Vouchers", "LocationId", "Locations");
            DropForeignKey("Receipts", "LocationId", "Locations");
            DropForeignKey("Memos", "LocationId", "Locations");
            DropIndex("Vouchers", new[] { "LocationId" });
            DropIndex("Receipts", new[] { "LocationId" });
            DropIndex("Memos", new[] { "LocationId" });
            DropColumn("Vouchers", "LocationId");
            DropColumn("Receipts", "LocationId");
            DropColumn("Memos", "LocationId");
        }
    }
}
