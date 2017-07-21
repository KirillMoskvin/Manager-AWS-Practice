using CarServiceData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagerData.DataControllers
{
    public static class DataController
    {
        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        public static IList<Order> GetAllOrders()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                return (dbContext.Orders.Include("Car").Include("Car.TransmissionType").Include("Car.CarMark")).ToList();
            }
        }

        /// <summary>
        /// добавление заказа
        /// </summary>
        /// <param name="ord"></param>
        public static bool AddOrder(Order ord)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.Orders.Contains(ord))
                {
                    dbContext.Orders.Add(ord);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="ord">заказ</param>
        public static bool RemoveOrder(Order ord)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.Orders.Contains(ord))
                {
                    dbContext.Orders.Remove(ord);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Получение всех автомобилей
        /// </summary>
        /// <returns></returns>
        public static IList<Car> GetAllCars()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                return (dbContext.Cars.Include("Car.TransmissionType").Include("Car.CarMark")).ToList();
            }
        }

        /// <summary>
        /// Добавление автомобиля
        /// </summary>
        /// <param name="ord"></param>
        public static bool AddCar(Car car)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.Cars.Contains(car))
                {
                    dbContext.Cars.Add(car);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Удаление автомобиля
        /// </summary>
        /// <param name="ord">заказ</param>
        public static bool RemoveCar(Car car)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (dbContext.Cars.Contains(car))
                {
                    dbContext.Cars.Remove(car);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Получение всех заказчиков
        /// </summary>
        /// <returns></returns>
        public static IList<Customer> GetAllCustomers()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                return (dbContext.Customers.Include("Cars")).ToList();
            }
        }

        /// <summary>
        /// добавление заказчика
        /// </summary>
        /// <param name="ord"></param>
        public static bool AddCustomer(Customer customer)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.Customers.Contains(customer))
                {
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Удаление заказчика
        /// </summary>
        /// <param name="ord">заказ</param>
        public static bool RemoveCustomer(Customer customer)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (dbContext.Customers.Contains(customer))
                {
                    dbContext.Customers.Remove(customer);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Получение всех марок автомобиля
        /// </summary>
        /// <returns></returns>
        public static IList<CarMark> GetAllCarMarks()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                return (dbContext.CarMarks).ToList();
            }
        }

        /// <summary>
        /// добавление марки машины
        /// </summary>
        /// <param name="ord"></param>
        public static bool AddCarMark(CarMark cm)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.CarMarks.Contains(cm))
                {
                    dbContext.CarMarks.Add(cm);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Удаление марки машины
        /// </summary>
        /// <param name="ord">заказ</param>
        public static bool RemoveCarMark(CarMark cm)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.CarMarks.Contains(cm))
                {
                    dbContext.CarMarks.Remove(cm);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Получение всех типов трансмиссии
        /// </summary>
        /// <returns></returns>
        public static IList<TransmissionType> GetAllTransmissionTypes()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                return (dbContext.TransmissionTypes).ToList();
            }
        }

        /// <summary>
        /// Добавление типа  трансмиссии
        /// </summary>
        /// <param name="ord"></param>
        public static bool AddTransmissionType(TransmissionType tt)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.TransmissionTypes.Contains(tt))
                {
                    dbContext.TransmissionTypes.Add(tt);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Удаление типа трансмиссии
        /// </summary>
        /// <param name="ord">заказ</param>
        public static bool RemoveTransmissionType(TransmissionType tt)
        {
            using (DBContext dbContext = new DBContext())
            {
                if (!dbContext.TransmissionTypes.Contains(tt))
                {
                    dbContext.TransmissionTypes.Remove(tt);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}
