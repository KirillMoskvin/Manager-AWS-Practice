using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagerData.ViewModels
{
    /// <summary>
    /// Перечисление столбцов
    /// </summary>
    public enum TableColumns
    {
        ID = 0,
        CarMark = 1,
        CarModel = 2,
        CarYear = 3,
        CarTransmissionType = 4,
        CarEnginePower = 5,
        WorkType = 6,
        WorkStart = 7,
        WorkEnd = 8,
        Cost = 9
    }
}
