namespace Premium89.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cart : DbMigration
    {
        public override void Up()
        {
            DropIndex("public.Categories", new[] { "CategoryName" });
            CreateTable(
                "public.CartItems",
                c => new
                    {
                        CartItemId = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Active = c.String(nullable: false, maxLength: 1),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("public.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("public.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "public.Orders",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        GrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingAddress = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Active = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("public.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "public.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTHB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Long(nullable: false),
                        Active = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("public.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("public.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "public.WishLists",
                c => new
                    {
                        WishListId = c.Long(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Long(nullable: false),
                        Active = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.WishListId)
                .ForeignKey("public.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("public.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            AddColumn("public.Products", "OriginalPriceTHB", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("public.Products", "SaleStartPeriod", c => c.DateTime());
            AddColumn("public.Products", "SaleEndPeriod", c => c.DateTime());
            AddColumn("public.Products", "DiscountedPriceTHB", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("public.Sizes", "Active", c => c.String(nullable: false, maxLength: 1));
            AddColumn("public.SizeGroups", "Active", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("public.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("public.Categories", "Active", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("public.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("public.Products", "Active", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("public.Colors", "ColorName", c => c.String(nullable: false));
            AlterColumn("public.Colors", "ColorRGB", c => c.String(nullable: false));
            AlterColumn("public.Colors", "Active", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("public.Links", "PhysicalPath", c => c.String(nullable: false));
            AlterColumn("public.Links", "FileName", c => c.String(nullable: false));
            AlterColumn("public.Links", "FileExtension", c => c.String(nullable: false));
            AlterColumn("public.Links", "Active", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("public.Sizes", "SizeName", c => c.String(nullable: false));
            AlterColumn("public.SizeGroups", "SizeGroupName", c => c.String(nullable: false));
            CreateIndex("public.Categories", "CategoryName", unique: true);
            DropColumn("public.Products", "PriceTHB");
        }
        
        public override void Down()
        {
            AddColumn("public.Products", "PriceTHB", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("public.WishLists", "UserId", "public.AspNetUsers");
            DropForeignKey("public.WishLists", "ProductId", "public.Products");
            DropForeignKey("public.Orders", "UserId", "public.AspNetUsers");
            DropForeignKey("public.OrderDetails", "ProductId", "public.Products");
            DropForeignKey("public.OrderDetails", "OrderId", "public.Orders");
            DropForeignKey("public.CartItems", "UserId", "public.AspNetUsers");
            DropForeignKey("public.CartItems", "ProductId", "public.Products");
            DropIndex("public.WishLists", new[] { "ProductId" });
            DropIndex("public.WishLists", new[] { "UserId" });
            DropIndex("public.OrderDetails", new[] { "OrderId" });
            DropIndex("public.OrderDetails", new[] { "ProductId" });
            DropIndex("public.Orders", new[] { "UserId" });
            DropIndex("public.CartItems", new[] { "UserId" });
            DropIndex("public.CartItems", new[] { "ProductId" });
            DropIndex("public.Categories", new[] { "CategoryName" });
            AlterColumn("public.SizeGroups", "SizeGroupName", c => c.String());
            AlterColumn("public.Sizes", "SizeName", c => c.String());
            AlterColumn("public.Links", "Active", c => c.String(maxLength: 1));
            AlterColumn("public.Links", "FileExtension", c => c.String());
            AlterColumn("public.Links", "FileName", c => c.String());
            AlterColumn("public.Links", "PhysicalPath", c => c.String());
            AlterColumn("public.Colors", "Active", c => c.String(maxLength: 1));
            AlterColumn("public.Colors", "ColorRGB", c => c.String());
            AlterColumn("public.Colors", "ColorName", c => c.String());
            AlterColumn("public.Products", "Active", c => c.String(maxLength: 1));
            AlterColumn("public.Products", "ProductName", c => c.String());
            AlterColumn("public.Categories", "Active", c => c.String(maxLength: 1));
            AlterColumn("public.Categories", "CategoryName", c => c.String());
            DropColumn("public.SizeGroups", "Active");
            DropColumn("public.Sizes", "Active");
            DropColumn("public.Products", "DiscountedPriceTHB");
            DropColumn("public.Products", "SaleEndPeriod");
            DropColumn("public.Products", "SaleStartPeriod");
            DropColumn("public.Products", "OriginalPriceTHB");
            DropTable("public.WishLists");
            DropTable("public.OrderDetails");
            DropTable("public.Orders");
            DropTable("public.CartItems");
            CreateIndex("public.Categories", "CategoryName", unique: true);
        }
    }
}
