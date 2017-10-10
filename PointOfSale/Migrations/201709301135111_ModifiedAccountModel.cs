namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAccountModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Accounts", "Fees", c => c.Boolean(nullable: false));
            AlterColumn("Accounts", "Budget", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Accounts", "Budget", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("Accounts", "Fees", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
