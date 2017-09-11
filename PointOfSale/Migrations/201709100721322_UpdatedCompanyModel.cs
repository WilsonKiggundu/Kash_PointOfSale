namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCompanyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("Companies", "Email", c => c.String(unicode: false));
            AlterColumn("Companies", "Landlord", c => c.Boolean());
            AlterColumn("Companies", "Occupant", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("Companies", "Occupant", c => c.Boolean(nullable: false));
            AlterColumn("Companies", "Landlord", c => c.Boolean(nullable: false));
            DropColumn("Companies", "Email");
        }
    }
}
