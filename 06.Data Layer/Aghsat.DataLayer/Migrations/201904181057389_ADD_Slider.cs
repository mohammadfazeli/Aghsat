namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_Slider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Menus", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Menus", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicles", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicles", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsActive");
            DropColumn("dbo.Vehicles", "IsDeleted");
            DropColumn("dbo.Menus", "IsActive");
            DropColumn("dbo.Menus", "IsDeleted");
            DropTable("dbo.Sliders");
        }
    }
}
