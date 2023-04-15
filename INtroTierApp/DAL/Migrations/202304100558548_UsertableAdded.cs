namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsertableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Username", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Username");
        }
    }
}
