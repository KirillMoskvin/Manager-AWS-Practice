using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;

namespace CarServiceData
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
        public int CarId { get; set; }
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
        public DateTime? WorkFinish { get; set;}
        /// <summary>
        /// Стоимость работ
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Свойство для формата вывода даты
        /// </summary>
        public string WorkStartDate
        {
            get { return WorkStart.ToString(CultureInfo.CurrentCulture); }
        }
        /// <summary>
        /// Свойство для формата вывода даты окончания работы
        /// </summary>
        public string WorkFinishDate
        {
            get
            {
                if (WorkFinish == null)
                    return "В процессе";
                return ((DateTime)WorkFinish).ToString(CultureInfo.CurrentCulture);
                    
            }
        }

    }
}
