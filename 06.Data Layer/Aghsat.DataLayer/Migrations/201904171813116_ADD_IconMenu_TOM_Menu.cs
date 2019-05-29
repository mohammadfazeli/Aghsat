namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_IconMenu_TOM_Menu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "IconMenu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "IconMenu");
        }
    }
}
