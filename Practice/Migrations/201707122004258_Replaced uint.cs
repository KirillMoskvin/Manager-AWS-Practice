namespace Practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Replaceduint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "EnginePower", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Cost");
            DropColumn("dbo.Cars", "EnginePower");
        }
    }
}
