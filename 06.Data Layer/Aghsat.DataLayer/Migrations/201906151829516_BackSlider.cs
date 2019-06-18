namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackSlider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "PictureName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Sliders", "DisplayPriority", c => c.Int());
            DropColumn("dbo.Sliders", "ImageName");
            DropColumn("dbo.Sliders", "order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "order", c => c.Int(nullable: false));
            AddColumn("dbo.Sliders", "ImageName", c => c.String());
            DropColumn("dbo.Sliders", "DisplayPriority");
            DropColumn("dbo.Sliders", "PictureName");
        }
    }
}
