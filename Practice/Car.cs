using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
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
        public uint EnginePower { get; set; }

        /// <summary>
        /// Id марки машины
        /// </summary>
        public int CarMarkId { get; set; }
        /// <summary>
        /// Название машины
        /// </summary>
        public CarMark Mark { get; set; }
        /// <summary>
        /// ID типа трансмиссии
        /// </summary>
        public int TypeOfTransmissionId { get; set; }
        /// <summary>
        /// Тип трансмиссии
        /// </summary>
        public TransmissionType TypeOfTransmission { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public Customer Owner { get; set; }
    }

    public class CarMark
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CarMarkId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }

    public class TransmissionType
    {
        /// <summary>
        /// Id
        /// </summary>
        public int TransmissionTypeId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
