namespace Practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarMarks",
                c => new
                    {
                        CarMarkId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CarMarkId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        CarMarkId = c.Int(nullable: false),
                        TypeOfTransmissionId = c.Int(nullable: false),
                        Owner_CustomerId = c.Int(),
                        TypeOfTransmission_TransmissionTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.CarMarks", t => t.CarMarkId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Owner_CustomerId)
                .ForeignKey("dbo.TransmissionTypes", t => t.TypeOfTransmission_TransmissionTypeId)
                .Index(t => t.CarMarkId)
                .Index(t => t.Owner_CustomerId)
                .Index(t => t.TypeOfTransmission_TransmissionTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        ThirdName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.TransmissionTypes",
                c => new
                    {
                        TransmissionTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionTypeId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Work = c.String(),
                        WorkStart = c.DateTime(nullable: false),
                        WorkFinish = c.DateTime(nullable: false),
                        Car_CarId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Cars", t => t.Car_CarId)
                .Index(t => t.Car_CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Car_CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "TypeOfTransmission_TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Cars", "Owner_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Cars", "CarMarkId", "dbo.CarMarks");
            DropIndex("dbo.Orders", new[] { "Car_CarId" });
            DropIndex("dbo.Cars", new[] { "TypeOfTransmission_TransmissionTypeId" });
            DropIndex("dbo.Cars", new[] { "Owner_CustomerId" });
            DropIndex("dbo.Cars", new[] { "CarMarkId" });
            DropTable("dbo.Orders");
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
            DropTable("dbo.CarMarks");
        }
    }
}
