namespace Practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedCar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Owner_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Cars", "TypeOfTransmission_TransmissionTypeId", "dbo.TransmissionTypes");
            DropIndex("dbo.Cars", new[] { "Owner_CustomerId" });
            DropIndex("dbo.Cars", new[] { "TypeOfTransmission_TransmissionTypeId" });
            RenameColumn(table: "dbo.Cars", name: "Owner_CustomerId", newName: "CustomerId");
            RenameColumn(table: "dbo.Cars", name: "TypeOfTransmission_TransmissionTypeId", newName: "TransmissionTypeId");
            AlterColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "TransmissionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "TransmissionTypeId");
            CreateIndex("dbo.Cars", "CustomerId");
            AddForeignKey("dbo.Cars", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "TransmissionTypeId", "dbo.TransmissionTypes", "TransmissionTypeId", cascadeDelete: true);
            DropColumn("dbo.Cars", "TypeOfTransmissionId");
            DropColumn("dbo.Cars", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "OwnerId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "TypeOfTransmissionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            DropIndex("dbo.Cars", new[] { "TransmissionTypeId" });
            AlterColumn("dbo.Cars", "TransmissionTypeId", c => c.Int());
            AlterColumn("dbo.Cars", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "TransmissionTypeId", newName: "TypeOfTransmission_TransmissionTypeId");
            RenameColumn(table: "dbo.Cars", name: "CustomerId", newName: "Owner_CustomerId");
            CreateIndex("dbo.Cars", "TypeOfTransmission_TransmissionTypeId");
            CreateIndex("dbo.Cars", "Owner_CustomerId");
            AddForeignKey("dbo.Cars", "TypeOfTransmission_TransmissionTypeId", "dbo.TransmissionTypes", "TransmissionTypeId");
            AddForeignKey("dbo.Cars", "Owner_CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
