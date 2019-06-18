namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_PictureAnd_AutoMapperConfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "ProductDetailId", "dbo.ProductDetails");
            DropIndex("dbo.Pictures", new[] { "Name" });
            DropIndex("dbo.Pictures", new[] { "ProductDetailId" });
            AddColumn("dbo.Pictures", "PictureName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Pictures", "ShortDescription", c => c.String(maxLength: 50));
            AddColumn("dbo.Pictures", "SliderId", c => c.Int());
            AlterColumn("dbo.Pictures", "ProductDetailId", c => c.Int());
            CreateIndex("dbo.Pictures", "PictureName", unique: true);
            CreateIndex("dbo.Pictures", "ProductDetailId");
            CreateIndex("dbo.Pictures", "SliderId");
            AddForeignKey("dbo.Pictures", "SliderId", "dbo.Sliders", "Id");
            AddForeignKey("dbo.Pictures", "ProductDetailId", "dbo.ProductDetails", "Id");
            DropColumn("dbo.Pictures", "Name");
            DropColumn("dbo.Sliders", "ImageName");
            DropColumn("dbo.Sliders", "ShortDescription");
            DropColumn("dbo.Sliders", "order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "order", c => c.Int(nullable: false));
            AddColumn("dbo.Sliders", "ShortDescription", c => c.String());
            AddColumn("dbo.Sliders", "ImageName", c => c.String());
            AddColumn("dbo.Pictures", "Name", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.Pictures", "ProductDetailId", "dbo.ProductDetails");
            DropForeignKey("dbo.Pictures", "SliderId", "dbo.Sliders");
            DropIndex("dbo.Pictures", new[] { "SliderId" });
            DropIndex("dbo.Pictures", new[] { "ProductDetailId" });
            DropIndex("dbo.Pictures", new[] { "PictureName" });
            AlterColumn("dbo.Pictures", "ProductDetailId", c => c.Int(nullable: false));
            DropColumn("dbo.Pictures", "SliderId");
            DropColumn("dbo.Pictures", "ShortDescription");
            DropColumn("dbo.Pictures", "PictureName");
            CreateIndex("dbo.Pictures", "ProductDetailId");
            CreateIndex("dbo.Pictures", "Name", unique: true);
            AddForeignKey("dbo.Pictures", "ProductDetailId", "dbo.ProductDetails", "Id", cascadeDelete: true);
        }
    }
}
