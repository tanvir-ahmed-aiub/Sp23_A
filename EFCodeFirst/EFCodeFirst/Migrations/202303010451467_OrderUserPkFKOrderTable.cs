namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUserPkFKOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Username);
            
            AddColumn("dbo.Orders", "OrderByUserId", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "OrderByUserId");
            AddForeignKey("dbo.Orders", "OrderByUserId", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderByUserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "OrderByUserId" });
            DropColumn("dbo.Orders", "OrderByUserId");
            DropTable("dbo.Users");
        }
    }
}
