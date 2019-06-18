namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backToGood : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Slider_Id", "dbo.Sliders");
            DropIndex("dbo.Pictures", new[] { "Slider_Id" });
            AddColumn("dbo.Sliders", "ImageName", c => c.String());
            AddColumn("dbo.Sliders", "ShortDescription", c => c.String());
            AddColumn("dbo.Sliders", "order", c => c.Int(nullable: false));
            DropColumn("dbo.Pictures", "SliderId");
            DropColumn("dbo.Pictures", "Slider_Id");
            DropColumn("dbo.Sliders", "PictureId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "PictureId", c => c.Int());
            AddColumn("dbo.Pictures", "Slider_Id", c => c.Int());
            AddColumn("dbo.Pictures", "SliderId", c => c.Int());
            DropColumn("dbo.Sliders", "order");
            DropColumn("dbo.Sliders", "ShortDescription");
            DropColumn("dbo.Sliders", "ImageName");
            CreateIndex("dbo.Pictures", "Slider_Id");
            AddForeignKey("dbo.Pictures", "Slider_Id", "dbo.Sliders", "Id");
        }
    }
}
