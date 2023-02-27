namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKPKOrderOrderDetailsProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                        OId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.OId);
            
            AddColumn("dbo.Products", "Cid", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Price", c => c.Int());
            CreateIndex("dbo.Products", "Cid");
            AddForeignKey("dbo.Products", "Cid", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OId", "dbo.Orders");
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "OId" });
            DropIndex("dbo.OrderDetails", new[] { "PId" });
            DropIndex("dbo.Products", new[] { "Cid" });
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Cid");
            DropTable("dbo.OrderDetails");
        }
    }
}
