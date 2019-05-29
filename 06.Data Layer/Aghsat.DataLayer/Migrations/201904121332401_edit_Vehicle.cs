namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_Vehicle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Vehicles", "Vin", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Vin", c => c.String());
            AlterColumn("dbo.Vehicles", "Name", c => c.String());
        }
    }
}
