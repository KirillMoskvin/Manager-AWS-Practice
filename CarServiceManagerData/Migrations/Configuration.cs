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
                new CarMark { Name = "Audi" },
                new CarMark { Name = "Ford" },
                new CarMark { Name = "KIA" },
                new CarMark { Name = "Volkswagen" },
                new CarMark { Name = "Toyota" }
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
                new Customer { SecondName = "Иванов", FirstName = "Иван", ThirdName = "Иванович", BirthDate = DateTime.Parse("1992-01-02 0:00:00Z"), Phone = "2222222" },
                new Customer { SecondName = "Петров", FirstName = "Пётр",  ThirdName = "Петрович", BirthDate = DateTime.Parse("1982-03-05 0:00:00Z"), Phone = "3333333" },
                new Customer { SecondName = "Васильев", FirstName = "Василий",  ThirdName = "Васильевич", BirthDate = DateTime.Parse("1995-03-03 0:00:00Z"), Phone = "4444444" },
                new Customer { SecondName = "Сидоров", FirstName = "Сидор",  ThirdName = "Сидорович", BirthDate = DateTime.Parse("1959-05-08 0:00:00Z"), Phone = "4444444" },
                new Customer { SecondName = "Александрин", FirstName = "Василий",  ThirdName = "Васильевич", BirthDate = DateTime.Parse("1978-01-01 0:00:00Z"), Phone = "5555555" },
                new Customer { SecondName = "Державин", FirstName = "Юрий",  ThirdName = "Трофимович", BirthDate = DateTime.Parse("1979-01-01 0:00:00Z"), Phone = "6210551" },
                new Customer { SecondName = "Ященко", FirstName = "Филипп",  ThirdName = "Вадимович", BirthDate = DateTime.Parse("1980-01-01 0:00:00Z"), Phone = "1946446" },
                new Customer { SecondName = "Полынов", FirstName = "Варфоломей",  ThirdName = "Эмилевич", BirthDate = DateTime.Parse("1981-01-01 0:00:00Z"), Phone = "0558733" },
                new Customer { SecondName = "Верица", FirstName = "Евграф",  ThirdName = "Прохорович", BirthDate = DateTime.Parse("1982-01-01 0:00:00Z"), Phone = "6156093" },
                new Customer { SecondName = "Пашин", FirstName = "Трофим",  ThirdName = "Якубович", BirthDate = DateTime.Parse("1983-01-01 0:00:00Z"), Phone = "1577194" },
                new Customer { SecondName = "Аверьянов", FirstName = "Изяслав",  ThirdName = "Саввевич", BirthDate = DateTime.Parse("1984-01-01 0:00:00Z"), Phone = "8883358" },
                new Customer { SecondName = "Двуреченский", FirstName = "Фома",  ThirdName = "Натанович", BirthDate = DateTime.Parse("1985-01-01 0:00:00Z"), Phone = "1338663" },
                new Customer { SecondName = "Есаулов", FirstName = "Якуб",  ThirdName = "Всеволодович", BirthDate = DateTime.Parse("1986-01-01 0:00:00Z"), Phone = "7998835" },
                new Customer { SecondName = "Шагидзянов", FirstName = "Прохор",  ThirdName = "Капитонович", BirthDate = DateTime.Parse("1987-01-01 0:00:00Z"), Phone = "8270112" },
                new Customer { SecondName = "Кожевников", FirstName = "Герасим",  ThirdName = "Миронович", BirthDate = DateTime.Parse("1988-01-01 0:00:00Z"), Phone = "0134728" },
                new Customer { SecondName = "Безродный", FirstName = "Фадей",  ThirdName = "Агапович", BirthDate = DateTime.Parse("1989-01-01 0:00:00Z"), Phone = "5172806" },
                new Customer { SecondName = "Седельников", FirstName = "Гавриил",  ThirdName = "Никанорович", BirthDate = DateTime.Parse("1990-01-01 0:00:00Z"), Phone = "0548998" },
                new Customer { SecondName = "Сергеев", FirstName = "Ефим",  ThirdName = "Мечиславович", BirthDate = DateTime.Parse("1991-01-01 0:00:00Z"), Phone = "2584614" },
                new Customer { SecondName = "Савкин", FirstName = "Виталий",  ThirdName = "Вячеславович", BirthDate = DateTime.Parse("1992-01-01 0:00:00Z"), Phone = "3811000" },
                new Customer { SecondName = "Курбонмамадов", FirstName = "Феликс",  ThirdName = "Онисимович", BirthDate = DateTime.Parse("1993-01-01 0:00:00Z"), Phone = "1780856" },
                new Customer { SecondName = "Шатов", FirstName = "Филимон",  ThirdName = "Модестович", BirthDate = DateTime.Parse("1994-01-01 0:00:00Z"), Phone = "1170159" },
                new Customer { SecondName = "Смирновский", FirstName = "Прокл",  ThirdName = "Еремеевич", BirthDate = DateTime.Parse("1995-01-01 0:00:00Z"), Phone = "1878925" },
                new Customer { SecondName = "Цур", FirstName = "Владислав",  ThirdName = "Михеевич", BirthDate = DateTime.Parse("1996-01-01 0:00:00Z"), Phone = "0751757" },
                new Customer { SecondName = "Перевёртов", FirstName = "Василий",  ThirdName = "Никитич", BirthDate = DateTime.Parse("1997-01-01 0:00:00Z"), Phone = "3692161" },
                new Customer { SecondName = "Королёва", FirstName = "Нина",  ThirdName = "Макаровна", BirthDate = DateTime.Parse("1998-01-01 0:00:00Z"), Phone = "7938521" },
                new Customer { SecondName = "Фомина", FirstName = "Альбина",  ThirdName = "Авдеевна", BirthDate = DateTime.Parse("1977-01-01 0:00:00Z"), Phone = "0940104" },
                new Customer { SecondName = "Рудникова", FirstName = "Кира",  ThirdName = "Сергеевна", BirthDate = DateTime.Parse("1976-01-01 0:00:00Z"), Phone = "7934503" },
                new Customer { SecondName = "Шеповалова", FirstName = "Лидия",  ThirdName = "Прокловна", BirthDate = DateTime.Parse("1975-01-01 0:00:00Z"), Phone = "7319931" },
                new Customer { SecondName = "Жмылева", FirstName = "Александра",  ThirdName = "Анатолиевна", BirthDate = DateTime.Parse("1974-01-01 0:00:00Z"), Phone = "2457774" },
                new Customer { SecondName = "Кабинова", FirstName = "Роза",  ThirdName = "Прокофьевна", BirthDate = DateTime.Parse("1973-01-01 0:00:00Z"), Phone = "6877929" },
                new Customer { SecondName = "Расторгуева", FirstName = "Ева",  ThirdName = "Карловна", BirthDate = DateTime.Parse("1972-01-01 0:00:00Z"), Phone = "1316456" },
                new Customer { SecondName = "Якушкова", FirstName = "Алла",  ThirdName = "Тарасовна", BirthDate = DateTime.Parse("1971-01-01 0:00:00Z"), Phone = "8807123" },
                new Customer { SecondName = "Унгерна", FirstName = "Екатерина",  ThirdName = "Дмитриевна", BirthDate = DateTime.Parse("1970-01-01 0:00:00Z"), Phone = "7924662" },
                new Customer { SecondName = "Толмачёва", FirstName = "Ариадна",  ThirdName = "Платоновна", BirthDate = DateTime.Parse("1969-01-01 0:00:00Z"), Phone = "5004201" },
                new Customer { SecondName = "Степанов", FirstName = "Степан",  ThirdName = "Степанович", BirthDate = DateTime.Parse("1968-05-21 0:00:00Z"), Phone = "3217778" }
            };
            foreach (Customer customer in customers)
                context.Customers.Add(customer);

            List<Car> cars = new List<Car> {
                new Car { CarMark = marks[0], Model = "V3", Customer = customers[0], EnginePower = 100, TransmissionType = types[0], Year = 2000 },
                new Car { CarMark = marks[1], Model = "Logan", Customer = customers[1], EnginePower = 120, TransmissionType = types[1], Year = 2001 },
                new Car { CarMark = marks[2], Model = "X3", Customer = customers[2], EnginePower = 130, TransmissionType = types[2], Year = 2002 },
                new Car { CarMark = marks[3], Model = "Kalina", Customer = customers[3], EnginePower = 150, TransmissionType = types[3], Year = 2003 },
                new Car { CarMark = marks[4], Model = "C-class", Customer = customers[4], EnginePower = 170, TransmissionType = types[4], Year = 1997 },
                new Car { CarMark = marks[5], Model = "A3", Customer = customers[5], EnginePower = 180, TransmissionType = types[0], Year = 2000 },
                new Car { CarMark = marks[6], Model = "Fiesta", Customer = customers[6], EnginePower = 190, TransmissionType = types[1], Year = 2001 },
                new Car { CarMark = marks[7], Model = "Rio", Customer = customers[7], EnginePower = 100, TransmissionType = types[2], Year = 2002 },
                new Car { CarMark = marks[8], Model = "Polo", Customer = customers[8], EnginePower = 110, TransmissionType = types[3], Year = 2003 },
                new Car { CarMark = marks[9], Model = "Corolla", Customer = customers[9], EnginePower = 120, TransmissionType = types[4], Year = 2004 },
                new Car { CarMark = marks[0], Model = "S60", Customer = customers[10], EnginePower = 130, TransmissionType = types[0], Year = 2005 },
                new Car { CarMark = marks[1], Model = "Fluence", Customer = customers[11], EnginePower = 140, TransmissionType = types[1], Year = 2006 },
                new Car { CarMark = marks[2], Model = "2", Customer = customers[12], EnginePower = 150, TransmissionType = types[2], Year = 2007 },
                new Car { CarMark = marks[3], Model = "Granta", Customer = customers[13], EnginePower = 160, TransmissionType = types[3], Year = 2008 },
                new Car { CarMark = marks[4], Model = "CLA", Customer = customers[14], EnginePower = 170, TransmissionType = types[4], Year = 2009 },
                new Car { CarMark = marks[5], Model = "A4", Customer = customers[15], EnginePower = 180, TransmissionType = types[0], Year = 2010 },
                new Car { CarMark = marks[6], Model = "Focus", Customer = customers[16], EnginePower = 190, TransmissionType = types[1], Year = 2011 },
                new Car { CarMark = marks[7], Model = "Cerato", Customer = customers[17], EnginePower = 200, TransmissionType = types[2], Year = 2012 },
                new Car { CarMark = marks[8], Model = "Jetta", Customer = customers[18], EnginePower = 210, TransmissionType = types[3], Year = 2013 },
                new Car { CarMark = marks[9], Model = "Camry", Customer = customers[19], EnginePower = 215, TransmissionType = types[4], Year = 2014 },
                new Car { CarMark = marks[0], Model = "V40", Customer = customers[20], EnginePower = 220, TransmissionType = types[0], Year = 2015 },
                new Car { CarMark = marks[1], Model = "Sandero", Customer = customers[21], EnginePower = 221, TransmissionType = types[1], Year = 2016 },
                new Car { CarMark = marks[2], Model = "3", Customer = customers[22], EnginePower = 222, TransmissionType = types[2], Year = 2017 },
                new Car { CarMark = marks[3], Model = "Vesta", Customer = customers[23], EnginePower = 223, TransmissionType = types[3], Year = 2016 },
                new Car { CarMark = marks[4], Model = "E-class", Customer = customers[24], EnginePower = 224, TransmissionType = types[4], Year = 2015 },
                new Car { CarMark = marks[5], Model = "A5", Customer = customers[25], EnginePower = 176, TransmissionType = types[0], Year = 2014 },
                new Car { CarMark = marks[6], Model = "Mondeo", Customer = customers[26], EnginePower = 156, TransmissionType = types[1], Year = 2013 },
                new Car { CarMark = marks[7], Model = "Optima", Customer = customers[27], EnginePower = 144, TransmissionType = types[2], Year = 2012 },
                new Car { CarMark = marks[8], Model = "Passat", Customer = customers[28], EnginePower = 182, TransmissionType = types[3], Year = 2011 },
                new Car { CarMark = marks[9], Model = "Prius", Customer = customers[29], EnginePower = 156, TransmissionType = types[4], Year = 2010 },
                new Car { CarMark = marks[0], Model = "V90", Customer = customers[30], EnginePower = 134, TransmissionType = types[0], Year = 2009 },
                new Car { CarMark = marks[1], Model = "Duster", Customer = customers[1], EnginePower = 197, TransmissionType = types[1], Year = 2008 },
                new Car { CarMark = marks[2], Model = "4", Customer = customers[32], EnginePower = 152, TransmissionType = types[2], Year = 2007 },
                new Car { CarMark = marks[3], Model = "XRay", Customer = customers[33], EnginePower = 143, TransmissionType = types[3], Year = 2006 },
                new Car { CarMark = marks[4], Model = "S-Class", Customer = customers[34], EnginePower = 163, TransmissionType = types[4], Year = 2005 },
                new Car { CarMark = marks[1], Model = "Kaptur", Customer = customers[5], EnginePower = 200, TransmissionType = types[1], Year = 2004 }
                };
            foreach (Car car in cars)
                context.Cars.AddOrUpdate(car);

            context.Orders.AddOrUpdate(
                new Order { Car = cars[0], Cost = 1000, Work = "Покраска кузова", WorkStart = DateTime.Parse("2017-02-03 12:32:00Z"), WorkFinish = DateTime.Parse("2017-02-05 16:20:00Z") },
                new Order { Car = cars[1], Cost = 2000, Work = "Работы с проводкой", WorkStart = DateTime.Parse("2017-03-03 13:32:00Z"), WorkFinish = DateTime.Parse("2017-03-05 11:10:00Z") },
                new Order { Car = cars[2], Cost = 3000, Work = "Замена масла", WorkStart = DateTime.Parse("2017-02-03 12:32:00Z"), WorkFinish = DateTime.Parse("2017-02-05 17:05:00Z") },
                new Order { Car = cars[3], Cost = 4000, Work = "Замена свеч", WorkStart = DateTime.Parse("2017-02-01 14:25:00Z"), WorkFinish = DateTime.Parse("2017-02-05 16:21:00Z") },
                new Order { Car = cars[4], Cost = 5000, Work = "Ремонт двигателя", WorkStart = DateTime.Parse("2017-06-13 11:56:00Z"), WorkFinish = null },
                new Order { Car = cars[5], Cost = 6000, Work = "Покраска кузова", WorkStart = DateTime.Parse("2017-02-01 09:44:00Z"), WorkFinish = DateTime.Parse("2017-02-05 19:32:00Z") },
                new Order { Car = cars[6], Cost = 6000, Work = "Технический осмотр", WorkStart = DateTime.Parse("2017-03-02 10:46:00Z"), WorkFinish = DateTime.Parse("2017-03-02 18:46:00Z") },
                new Order { Car = cars[7], Cost = 7000, Work = "Замена бампера", WorkStart = DateTime.Parse("2017-04-03 11:48:00Z"), WorkFinish = DateTime.Parse("2017-04-05 16:00:00Z") },
                new Order { Car = cars[8], Cost = 2700, Work = "Ремонт замка двери", WorkStart = DateTime.Parse("2017-05-04 12:50:00Z"), WorkFinish = DateTime.Parse("2017-05-09 12:05:00Z") },
                new Order { Car = cars[9], Cost = 2300, Work = "Замена стеклоподъемника", WorkStart = DateTime.Parse("2017-06-05 13:52:00Z"), WorkFinish = DateTime.Parse("2017-06-12 16:11:00Z") },
                new Order { Car = cars[10], Cost = 5400, Work = "Замена радиатора печки", WorkStart = DateTime.Parse("2017-07-06 14:55:00Z"), WorkFinish = DateTime.Parse("2017-07-21 14:23:00Z") },
                new Order { Car = cars[11], Cost = 5700, Work = "Установка фаркопа", WorkStart = DateTime.Parse("2017-01-07 15:58:00Z"), WorkFinish = null },
                new Order { Car = cars[12], Cost = 10000, Work = "Установка номерных знаков", WorkStart = DateTime.Parse("2017-02-08 16:02:00Z"), WorkFinish = DateTime.Parse("2017-02-13 15:25:00Z") },
                new Order { Car = cars[13], Cost = 13000, Work = "Замена лобового стекла", WorkStart = DateTime.Parse("2017-03-09 17:06:00Z"), WorkFinish = DateTime.Parse("2017-03-15 11:27:00Z") },
                new Order { Car = cars[14], Cost = 5600, Work = "Шумоизоляция пола", WorkStart = DateTime.Parse("2017-04-10 18:10:00Z"), WorkFinish = DateTime.Parse("2017-04-13 12:29:00Z") },
                new Order { Car = cars[15], Cost = 2000, Work = "Шумоизоляция дверей", WorkStart = DateTime.Parse("2017-03-11 19:15:00Z"), WorkFinish = null },
                new Order { Car = cars[16], Cost = 700, Work = "Шумоизоляция потолка", WorkStart = DateTime.Parse("2017-04-12 18:21:00Z"), WorkFinish = null },
                new Order { Car = cars[17], Cost = 600, Work = "Контрольный осмотр", WorkStart = DateTime.Parse("2017-05-13 17:27:00Z"), WorkFinish = DateTime.Parse("2017-05-16 13:32:00Z") },
                new Order { Car = cars[18], Cost = 1200, Work = "Замена топливного насоса", WorkStart = DateTime.Parse("2017-06-14 16:34:00Z"), WorkFinish = DateTime.Parse("2017-06-15 15:35:00Z") },
                new Order { Car = cars[19], Cost = 2400, Work = "Замена топливного фильтра", WorkStart = DateTime.Parse("2017-07-15 15:42:00Z"), WorkFinish = DateTime.Parse("2017-07-19 14:38:00Z") },
                new Order { Car = cars[20], Cost = 4800, Work = "Промывка инжектора", WorkStart = DateTime.Parse("2017-06-16 14:51:00Z"), WorkFinish = DateTime.Parse("2017-06-20 06:41:00Z") },
                new Order { Car = cars[21], Cost = 9600, Work = "Замена тормозной жидкости", WorkStart = DateTime.Parse("2017-01-17 13:00:00Z"), WorkFinish = null },
                new Order { Car = cars[22], Cost = 4400, Work = "Замена масла", WorkStart = DateTime.Parse("2017-02-18 12:10:00Z"), WorkFinish = DateTime.Parse("2017-02-23 08:45:00Z") },
                new Order { Car = cars[23], Cost = 4800, Work = "Ремонт КПП", WorkStart = DateTime.Parse("2017-03-19 11:11:00Z"), WorkFinish = DateTime.Parse("2017-03-22 09:49:00Z") },
                new Order { Car = cars[24], Cost = 5200, Work = "Технический осмотр", WorkStart = DateTime.Parse("2017-07-20 10:23:00Z"), WorkFinish = DateTime.Parse("2017-07-25 11:53:00Z") },
                new Order { Car = cars[25], Cost = 5600, Work = "Замена топливного фильтра", WorkStart = DateTime.Parse("2017-01-21 09:36:00Z"), WorkFinish = null },
                new Order { Car = cars[26], Cost = 2500, Work = "Замена масла", WorkStart = DateTime.Parse("2017-03-22 08:50:00Z"), WorkFinish = DateTime.Parse("2017-03-24 12:58:00Z") },
                new Order { Car = cars[27], Cost = 1500, Work = "Технический осмотр", WorkStart = DateTime.Parse("2017-05-23 07:05:00Z"), WorkFinish = DateTime.Parse("2017-05-26 16:03:00Z") },
                new Order { Car = cars[28], Cost = 1300, Work = "Замена бампера", WorkStart = DateTime.Parse("2017-04-24 11:06:00Z"), WorkFinish = DateTime.Parse("2017-04-28 17:08:00Z") },
                new Order { Car = cars[29], Cost = 1200, Work = "Замена масла", WorkStart = DateTime.Parse("2017-07-25 12:47:00Z"), WorkFinish = null },
                new Order { Car = cars[30], Cost = 2200, Work = "Покраска кузова", WorkStart = DateTime.Parse("2017-03-26 13:09:00Z"), WorkFinish = DateTime.Parse("2017-03-28 20:13:00Z") },
                new Order { Car = cars[31], Cost = 1100, Work = "Замена тормозной жидкости", WorkStart = DateTime.Parse("2017-01-27 14:12:00Z"), WorkFinish = DateTime.Parse("2017-02-03 21:18:00Z") },
                new Order { Car = cars[33], Cost = 4200, Work = "Ремонт КПП", WorkStart = DateTime.Parse("2017-05-30 14:27:00Z"), WorkFinish = DateTime.Parse("2017-06-10 12:30:00Z") },
                new Order { Car = cars[5], Cost = 6000, Work = "Покраска кузова", WorkStart = DateTime.Parse("2017-07-15 16:34:00Z"), WorkFinish = DateTime.Parse("2017-07-25 13:36:00Z") },
                new Order { Car = cars[7], Cost = 7000, Work = "Замена свеч", WorkStart = DateTime.Parse("2017-02-25 17:42:00Z"), WorkFinish = DateTime.Parse("2017-02-28 15:42:00Z") },
                new Order { Car = cars[13], Cost = 6000, Work = "Технический осмотр", WorkStart = DateTime.Parse("2017-06-23 15:51:00Z"), WorkFinish = null },
                new Order { Car = cars[24], Cost = 8000, Work = "Замена охлаждающей жидкости", WorkStart = DateTime.Parse("2017-03-21 16:01:00Z"), WorkFinish = DateTime.Parse("2017-03-28 17:49:00Z") },
                new Order { Car = cars[9], Cost = 9000, Work = "Замена свеч", WorkStart = DateTime.Parse("2017-03-20 17:12:00Z"), WorkFinish = DateTime.Parse("2017-03-29 16:56:00Z") },
                new Order { Car = cars[11], Cost = 10000, Work = "Замена охлаждающей жидкости", WorkStart = DateTime.Parse("2017-07-18 19:23:00Z"), WorkFinish = null },
                new Order { Car = cars[28], Cost = 8200, Work = "Сход-развал", WorkStart = DateTime.Parse("2017-03-15 20:25:00Z"), WorkFinish = DateTime.Parse("2017-03-27 15:04:00Z") },
                new Order { Car = cars[1], Cost = 5700, Work = "Ремонт КПП", WorkStart = DateTime.Parse("2017-03-12 15:54:00Z"), WorkFinish = DateTime.Parse("2017-03-17 18:12:00Z") },
                new Order { Car = cars[3], Cost = 5600, Work = "Замена бампера", WorkStart = DateTime.Parse("2017-05-10 14:12:00Z"), WorkFinish = DateTime.Parse("2017-05-16 19:20:00Z") },
                new Order { Car = cars[3], Cost = 4300, Work = "Замена тормозных колодок", WorkStart = DateTime.Parse("2017-01-08 13:43:00Z"), WorkFinish = DateTime.Parse("2017-01-12 20:28:00Z") },
                new Order { Car = cars[7], Cost = 3300, Work = "Ремонт стартера", WorkStart = DateTime.Parse("2017-02-06 12:45:00Z"), WorkFinish = DateTime.Parse("2017-02-09 08:36:00Z") },
                new Order { Car = cars[4], Cost = 2200, Work = "Шиномонтаж", WorkStart = DateTime.Parse("2017-07-04 11:45:00Z"), WorkFinish = null },
                new Order { Car = cars[8], Cost = 2100, Work = "Замена свеч", WorkStart = DateTime.Parse("2017-05-02 10:23:00Z"), WorkFinish = DateTime.Parse("2017-05-09 09:44:00Z") },
                new Order { Car = cars[21], Cost = 1600, Work = "Шиномонтаж", WorkStart = DateTime.Parse("2017-07-01 15:42:00Z"), WorkFinish = DateTime.Parse("2017-07-15 10:52:00Z") },
                new Order { Car = cars[12], Cost = 1700, Work = "Сход-развал", WorkStart = DateTime.Parse("2017-05-05 19:23:00Z"), WorkFinish = DateTime.Parse("2017-05-16 11:00:00Z") },
                new Order { Car = cars[13], Cost = 2600, Work = "Шиномонтаж", WorkStart = DateTime.Parse("2017-04-07 18:42:00Z"), WorkFinish = DateTime.Parse("2017-04-12 12:08:00Z") },
                new Order { Car = cars[18], Cost = 3500, Work = "Ремонт КПП", WorkStart = DateTime.Parse("2017-06-12 11:21:00Z"), WorkFinish = DateTime.Parse("2017-06-18 13:16:00Z") },
                new Order { Car = cars[22], Cost = 4400, Work = "Установка сигнализации", WorkStart = DateTime.Parse("2017-07-19 11:55:00Z"), WorkFinish = null },
                new Order { Car = cars[28], Cost = 1600, Work = "Шиномонтаж", WorkStart = DateTime.Parse("2017-03-02 11:27:00Z"), WorkFinish = DateTime.Parse("2017-03-16 14:25:00Z") }
                );
        }
    }
}
