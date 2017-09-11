namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTenantModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Tenants", "Category", c => c.Int(nullable: false));
            AlterColumn("Tenants", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Tenants", "Active", c => c.Int(nullable: false));
            AlterColumn("Tenants", "Category", c => c.String(unicode: false));
        }
    }
}
