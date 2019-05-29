namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_Order_Slider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "order");
        }
    }
}
