namespace CarServiceManagerData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "CarId" });
            RenameColumn(table: "dbo.Orders", name: "CarId", newName: "Car_CarId");
            AlterColumn("dbo.Orders", "Car_CarId", c => c.Int());
            CreateIndex("dbo.Orders", "Car_CarId");
            AddForeignKey("dbo.Orders", "Car_CarId", "dbo.Cars", "CarId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Car_CarId", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "Car_CarId" });
            AlterColumn("dbo.Orders", "Car_CarId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "Car_CarId", newName: "CarId");
            CreateIndex("dbo.Orders", "CarId");
            AddForeignKey("dbo.Orders", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
    }
}
