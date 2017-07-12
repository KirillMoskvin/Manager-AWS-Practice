using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Practice
{
    /// <summary>
    /// Класс клиента
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string ThirdName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Машины, принадлежащие этому клиенту
        /// </summary>
        public List<Car> Cars { get; set; }
    }
}
