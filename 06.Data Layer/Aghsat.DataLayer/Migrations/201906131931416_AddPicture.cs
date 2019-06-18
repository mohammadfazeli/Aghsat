namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPicture : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "SliderId", "dbo.Sliders");
            DropIndex("dbo.Pictures", new[] { "SliderId" });
            AddColumn("dbo.Pictures", "Slider_Id", c => c.Int());
            AddColumn("dbo.Sliders", "PictureId", c => c.Int());
            CreateIndex("dbo.Pictures", "Slider_Id");
            AddForeignKey("dbo.Pictures", "Slider_Id", "dbo.Sliders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Slider_Id", "dbo.Sliders");
            DropIndex("dbo.Pictures", new[] { "Slider_Id" });
            DropColumn("dbo.Sliders", "PictureId");
            DropColumn("dbo.Pictures", "Slider_Id");
            CreateIndex("dbo.Pictures", "SliderId");
            AddForeignKey("dbo.Pictures", "SliderId", "dbo.Sliders", "Id");
        }
    }
}
