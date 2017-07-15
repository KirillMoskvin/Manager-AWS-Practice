namespace CarServiceManagerData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Car_CarId", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "Car_CarId" });
            RenameColumn(table: "dbo.Orders", name: "Car_CarId", newName: "CarId");
            AlterColumn("dbo.Orders", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CarId");
            AddForeignKey("dbo.Orders", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "CarId" });
            AlterColumn("dbo.Orders", "CarId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "CarId", newName: "Car_CarId");
            CreateIndex("dbo.Orders", "Car_CarId");
            AddForeignKey("dbo.Orders", "Car_CarId", "dbo.Cars", "CarId");
        }
    }
}
