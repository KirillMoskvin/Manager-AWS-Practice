namespace CarServiceManagerData.Migrations
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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                        CarMarkId = c.Int(nullable: false),
                        TransmissionTypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.CarMarks", t => t.CarMarkId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .Index(t => t.CarMarkId)
                .Index(t => t.TransmissionTypeId)
                .Index(t => t.CustomerId);
            
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
                        CarId = c.Int(nullable: false),
                        Work = c.String(),
                        WorkStart = c.DateTime(nullable: false),
                        WorkFinish = c.DateTime(),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Cars", "CarMarkId", "dbo.CarMarks");
            DropIndex("dbo.Orders", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            DropIndex("dbo.Cars", new[] { "TransmissionTypeId" });
            DropIndex("dbo.Cars", new[] { "CarMarkId" });
            DropTable("dbo.Orders");
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
            DropTable("dbo.CarMarks");
        }
    }
}
