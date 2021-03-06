﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CarServiceData
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

        public string CustomerInfo
        {
            get {
                return "Фамилия: " + SecondName + Environment.NewLine +
                  "Имя: " + FirstName + Environment.NewLine +
                  "Отчество: " + ThirdName + Environment.NewLine +
                  "Год рождения: " + BirthDate.Year + Environment.NewLine +
                  "Телефон: " + Phone;
            }
        }
    }
}
