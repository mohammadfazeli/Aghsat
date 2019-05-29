namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formatdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductDate", c => c.DateTime(nullable: false));
        }
    }
}
