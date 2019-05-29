namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Menu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        ParentMenuId = c.Int(),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menus", t => t.ParentMenuId)
                .Index(t => t.ParentMenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "ParentMenuId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentMenuId" });
            DropTable("dbo.Menus");
        }
    }
}
