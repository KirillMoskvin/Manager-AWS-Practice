using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceData
{
    public class Car
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CarId { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Год выпуска
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Мощность двигателя
        /// </summary>
        public int EnginePower { get; set; }

        /// <summary>
        /// Id марки машины
        /// </summary>
        public int CarMarkId { get; set; }
        /// <summary>
        /// Название машины
        /// </summary>
        public CarMark CarMark { get; set; }
        /// <summary>
        /// ID типа трансмиссии
        /// </summary>
        public int TransmissionTypeId { get; set; }
        /// <summary>
        /// Тип трансмиссии
        /// </summary>
        public TransmissionType TransmissionType { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }

    public class CarMark
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }

    public class TransmissionType:IComparable
    {
        /// <summary>
        /// Id
        /// </summary>
        public int TransmissionTypeId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            return ((TransmissionType)obj).Name.CompareTo(this.Name);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
