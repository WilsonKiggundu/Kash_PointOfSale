namespace PointOfSale.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameAndUnitsToProductModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("Products", "Name", c => c.String(unicode: false));
            AddColumn("Products", "Units", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("Products", "Units");
            DropColumn("Products", "Name");
        }
    }
}
