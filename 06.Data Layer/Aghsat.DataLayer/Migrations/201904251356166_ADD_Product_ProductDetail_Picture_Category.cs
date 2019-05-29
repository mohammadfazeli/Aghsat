namespace Aghsat.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ADD_Product_ProductDetail_Picture_Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductDate = c.DateTime(nullable: false),
                        MainImage = c.String(),
                        UnitId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Int(nullable: false),
                        PriceDate = c.DateTime(nullable: false),
                        Inventory = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        ProductDetailId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductDetails", t => t.ProductDetailId, cascadeDelete: true)
                .Index(t => t.ProductDetailId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(),
                        ModifeDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "ProductDetailId", "dbo.ProductDetails");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropIndex("dbo.Pictures", new[] { "ProductDetailId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropTable("dbo.Units");
            DropTable("dbo.Pictures");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
