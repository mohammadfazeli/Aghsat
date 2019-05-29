namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_vehicle_property : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Vin", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Vin", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Vehicles", "Name", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
