using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Practice
{
    public class Order
    {
        /// <summary>
        /// ID
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Обслуживаемая машина
        /// </summary>
        public Car Car { get; set; }
        /// <summary>
        /// Работы
        /// </summary>
        public string Work { get; set; }  
        /// <summary>
        /// Дата начала работ
        /// </summary>
        public DateTime WorkStart { get; set; }
        /// <summary>
        /// Дата завершения работ
        /// </summary>
        public DateTime WorkFinish { get; set;}
        /// <summary>
        /// Стоимость работ
        /// </summary>
        public uint Cost { get; set; }
    }
}
