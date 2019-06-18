namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSomeEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "IsExist", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pictures", "DisplayPriority", c => c.Int());
            AlterColumn("dbo.Pictures", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Pictures", "Name", unique: true);
            DropColumn("dbo.Pictures", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Order", c => c.Int(nullable: false));
            DropIndex("dbo.Pictures", new[] { "Name" });
            AlterColumn("dbo.Pictures", "Name", c => c.String());
            DropColumn("dbo.Pictures", "DisplayPriority");
            DropColumn("dbo.ProductDetails", "IsExist");
        }
    }
}
