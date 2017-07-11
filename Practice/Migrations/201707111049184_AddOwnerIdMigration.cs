namespace Practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerIdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "OwnerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "OwnerId");
        }
    }
}
