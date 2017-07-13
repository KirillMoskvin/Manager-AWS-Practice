using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceData
{
    public class DBContext:DbContext
    {
        /// <summary>
        /// Клиенты
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Автомобили
        /// </summary>
        public DbSet<Car> Cars { get; set; }
        /// <summary>
        /// Макри автомобилей
        /// </summary>
        public DbSet<CarMark> CarMarks { get; set; }
        /// <summary>
        /// Типы трансмиссий
        /// </summary>
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        /// <summary>
        /// Список всех заказов
        /// </summary>
        public DbSet<Order> Orders { get; set; }
    }
}
