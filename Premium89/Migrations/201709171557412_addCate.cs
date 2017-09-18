namespace Premium89.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ParentCategoryId = c.Long(),
                        Active = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("public.Categories", t => t.ParentCategoryId)
                .Index(t => t.CategoryName, unique: true)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "public.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductShortDescription = c.String(),
                        ProductLongDescription = c.String(maxLength: 10000),
                        ProductSpecification = c.String(maxLength: 10000),
                        ItemLeft = c.Long(nullable: false),
                        PriceTHB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "public.Colors",
                c => new
                    {
                        ColorId = c.Long(nullable: false, identity: true),
                        ColorName = c.String(),
                        ColorRGB = c.String(),
                        Active = c.String(maxLength: 1),
                        Product_ProductId = c.Long(),
                    })
                .PrimaryKey(t => t.ColorId)
                .ForeignKey("public.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "public.Links",
                c => new
                    {
                        LinkId = c.Long(nullable: false, identity: true),
                        ServerDomain = c.String(),
                        PhysicalPath = c.String(),
                        FileName = c.String(),
                        FileExtension = c.String(),
                        Order = c.Int(nullable: false),
                        Active = c.String(maxLength: 1),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LinkId)
                .ForeignKey("public.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "public.Sizes",
                c => new
                    {
                        SizeId = c.Int(nullable: false, identity: true),
                        SizeName = c.String(),
                        SizeDescription = c.String(),
                        SizeGroupId = c.Int(),
                        Product_ProductId = c.Long(),
                    })
                .PrimaryKey(t => t.SizeId)
                .ForeignKey("public.SizeGroups", t => t.SizeGroupId)
                .ForeignKey("public.Products", t => t.Product_ProductId)
                .Index(t => t.SizeGroupId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "public.SizeGroups",
                c => new
                    {
                        SizeGroupId = c.Int(nullable: false, identity: true),
                        SizeGroupName = c.String(),
                    })
                .PrimaryKey(t => t.SizeGroupId);
            
            CreateTable(
                "public.ProductCategories",
                c => new
                    {
                        Product_ProductId = c.Long(nullable: false),
                        Category_CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Category_CategoryId })
                .ForeignKey("public.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("public.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Sizes", "Product_ProductId", "public.Products");
            DropForeignKey("public.Sizes", "SizeGroupId", "public.SizeGroups");
            DropForeignKey("public.Links", "ProductId", "public.Products");
            DropForeignKey("public.Colors", "Product_ProductId", "public.Products");
            DropForeignKey("public.ProductCategories", "Category_CategoryId", "public.Categories");
            DropForeignKey("public.ProductCategories", "Product_ProductId", "public.Products");
            DropForeignKey("public.Categories", "ParentCategoryId", "public.Categories");
            DropIndex("public.ProductCategories", new[] { "Category_CategoryId" });
            DropIndex("public.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("public.Sizes", new[] { "Product_ProductId" });
            DropIndex("public.Sizes", new[] { "SizeGroupId" });
            DropIndex("public.Links", new[] { "ProductId" });
            DropIndex("public.Colors", new[] { "Product_ProductId" });
            DropIndex("public.Categories", new[] { "ParentCategoryId" });
            DropIndex("public.Categories", new[] { "CategoryName" });
            DropTable("public.ProductCategories");
            DropTable("public.SizeGroups");
            DropTable("public.Sizes");
            DropTable("public.Links");
            DropTable("public.Colors");
            DropTable("public.Products");
            DropTable("public.Categories");
        }
    }
}
