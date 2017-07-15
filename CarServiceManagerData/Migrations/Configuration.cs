namespace CarServiceManagerData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarServiceData;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CarServiceData.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CarServiceData.DBContext";
        }

        protected override void Seed(CarServiceData.DBContext context)
        {
            List<CarMark> marks = new List<CarMark> {
                new CarMark { Name = "Volvo" },
                new CarMark { Name = "Renault" },
                new CarMark { Name = "BMW" },
                new CarMark { Name = "Lada" },
                new CarMark { Name = "Mercedes" },
                new CarMark { Name = "Nissan" }
                };
            foreach (CarMark mark in marks)
                context.CarMarks.AddOrUpdate(mark);
     
            List<TransmissionType> types = new List<TransmissionType> {
                new TransmissionType { Name = "Механическая" },
                new TransmissionType { Name = "Гидромеханическая" },
                new TransmissionType { Name = "Гидравлическая" },
                new TransmissionType { Name = "Электромеханическая" },
                new TransmissionType { Name = "Гидростатическая" }
                };
            foreach (TransmissionType type in types)
                context.TransmissionTypes.Add(type);

            List<Customer> customers = new List<Customer> {
                new Customer { FirstName = "Иванов", SecondName = "Иван", ThirdName = "Иванович", BirthDate = DateTime.Parse("1992-01-02 0:00:00Z"), Phone = "2222222" },
                new Customer { FirstName = "Петров", SecondName = "Пётр", ThirdName = "Петрович", BirthDate = DateTime.Parse("1982-03-05 0:00:00Z"), Phone = "3333333" },
                new Customer { FirstName = "Васильев", SecondName = "Василий", ThirdName = "Васильевич", BirthDate = DateTime.Parse("1995-03-03 0:00:00Z"), Phone = "4444444" },
                new Customer { FirstName = "Сидоров", SecondName = "Сидор", ThirdName = "Сидорович", BirthDate = DateTime.Parse("1959-05-08 0:00:00Z"), Phone = "4444444" },
                new Customer { FirstName = "Пупкин", SecondName = "Василий", ThirdName = "Васильевич", BirthDate = DateTime.Parse("1978-04-08 0:00:00Z"), Phone = "5555555" },
                new Customer { FirstName = "Степанов", SecondName = "Степан", ThirdName = "Степанович", BirthDate = DateTime.Parse("1982-05-21 0:00:00Z"), Phone = "6666666" }
            };
            foreach (Customer customer in customers)
                context.Customers.Add(customer);

            List<Car> cars = new List<Car> {
                new Car { CarMark = marks[0], Model = "V3", Customer = customers[0], EnginePower = 100, TransmissionType = types[0], Year = 2000 },
                new Car { CarMark = marks[1], Model = "Logan", Customer = customers[1], EnginePower = 120, TransmissionType = types[1], Year = 2001 },
                new Car { CarMark = marks[2], Model = "X3", Customer = customers[2], EnginePower = 130, TransmissionType = types[2], Year = 2002 },
                new Car { CarMark = marks[3], Model = "Kalina", Customer = customers[3], EnginePower = 150, TransmissionType = types[3], Year = 2003 },
                new Car { CarMark = marks[4], Model = "C-class", Customer = customers[4], EnginePower = 170, TransmissionType = types[4], Year = 1997 },
                new Car { CarMark = marks[0], Model = "Megan", Customer = customers[0], EnginePower = 180, TransmissionType = types[0], Year = 2002 },
                new Car { CarMark = marks[1], Model = "Quaskai", Customer = customers[5], EnginePower = 200, TransmissionType = types[1], Year = 2015 }
                };
            foreach (Car car in cars)
                context.Cars.AddOrUpdate(car);

            context.Orders.AddOrUpdate(
                new Order { Car = cars[0], Cost = 1000, Work = "Покраска", WorkStart = DateTime.Parse("2017-02-03 12:32:00Z"), WorkFinish = DateTime.Parse("2017-02-05 16:20:00Z") },
                new Order { Car = cars[1], Cost = 2000, Work = "Работы с проводкой", WorkStart = DateTime.Parse("2017-03-03 13:32:00Z"), WorkFinish = DateTime.Parse("2017-03-05 11:10:00Z") },
                new Order { Car = cars[2], Cost = 3000, Work = "Замена масла", WorkStart = DateTime.Parse("2017-02-03 12:32:00Z"), WorkFinish = DateTime.Parse("2017-02-05 17:05:00Z") },
                new Order { Car = cars[3], Cost = 4000, Work = "Замена свеч", WorkStart = DateTime.Parse("2017-02-01 14:25:00Z"), WorkFinish = DateTime.Parse("2017-02-05 16:21:00Z") },
                new Order { Car = cars[4], Cost = 5000, Work = "Ремонт двигателя", WorkStart = DateTime.Parse("2017-06-13 11:56:00Z"), WorkFinish = null },
                new Order { Car = cars[5], Cost = 6000, Work = "Ремонт КПП", WorkStart = DateTime.Parse("2017-02-04 13:44:00Z"), WorkFinish = DateTime.Parse("2017-02-05 19:32:00Z") },
                new Order { Car = cars[6], Cost = 7000, Work = "Установка сигнализации", WorkStart = DateTime.Parse("2017-07-19 11:55:00Z"), WorkFinish = null },
                new Order { Car = cars[0], Cost = 8000, Work = "Шиномонтаж", WorkStart = DateTime.Parse("2017-03-02 11:27:00Z"), WorkFinish = DateTime.Parse("2017-03-05 12:40:00Z") }
                );
        }
    }
}
