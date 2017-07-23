using CarServiceData;
using CarServiceManagerData.Helpers;
using CarServiceManagerData.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Helpers
{
    /// <summary>
    /// Возможные результаты поиска
    /// </summary>
    enum SearchResult
    {
        OK =0,
        NothingFound =1,
        Error = 2
    }


    class SearchHelper
    {
        const int MIN_CAR_YEAR = 1900;
        const int MAX_ENGINE_POWER = 2000;

        public static SearchResult SearchInCollection(ObservableCollection<Order> orders, TableColumns column, string searchedValue, ref string errorMessage)
        {
            List<Order> searchResults = null;
            switch (column)
            {
                case TableColumns.ID:
                    int id=0;
                    if (!ValidateID(searchedValue, ref id, ref errorMessage))
                        return SearchResult.Error;
                    searchResults = orders.Where(ord => ord.OrderId == id).ToList();
                    break;
                case TableColumns.CarMark:
                    searchResults = orders.Where(ord => ord.Car.CarMark.Name.ToUpper() == searchedValue.ToUpper()).ToList();
                    break;
                case TableColumns.CarModel:
                    searchResults = orders.Where(ord => ord.Car.Model.ToUpper() == searchedValue.ToUpper()).ToList();
                    break;
                case TableColumns.CarYear:
                    int year = 0;
                    if (!ValidateYear(searchedValue, ref year, ref errorMessage))
                        return SearchResult.Error;
                    searchResults = orders.Where(ord => ord.Car.Year == year).ToList();
                    break;
                case TableColumns.CarTransmissionType:
                    searchResults = orders.Where(ord => ord.Car.TransmissionType.Name.ToUpper() == searchedValue.ToUpper()).ToList();
                    break;
                case TableColumns.CarEnginePower:
                    int power = 0;
                    if (!ValidatePower(searchedValue, ref power, ref errorMessage))
                        return SearchResult.Error;
                    searchResults = orders.Where(ord => ord.Car.EnginePower == power).ToList();
                    break;
                case TableColumns.WorkType:
                    searchResults = orders.Where(ord => ord.Work.ToUpper() == searchedValue.ToUpper()).ToList();
                    break;
                case TableColumns.WorkStart:
                    DateTime date = DateTime.Today;
                    if (!ValidateDate(searchedValue, ref date, ref errorMessage))
                        return SearchResult.Error;
                    searchResults = orders.Where(ord => ord.WorkStart == date).ToList();
                    break;
                case TableColumns.WorkEnd:
                    DateTime dateFinish = DateTime.Today;
                    if (!ValidateDate(searchedValue, ref dateFinish, ref errorMessage))
                    {
                        if (searchedValue.ToUpper() != "В ПРОЦЕССЕ")
                            return SearchResult.Error;
                        else
                        {
                            searchResults = orders.Where(ord => ord.WorkFinish == null).ToList();
                            break;
                        }
                    }
                    searchResults = orders.Where(ord => ord.WorkStart == dateFinish).ToList();
                    break;
                case TableColumns.Cost:
                    int cost = 0;
                    if (!ValidateCost(searchedValue, ref cost, ref errorMessage))
                        return SearchResult.Error;
                    searchResults = orders.Where(ord => ord.Cost == cost).ToList();
                    break;
            }
            if (searchResults.Count==0)
                return SearchResult.NothingFound;
            orders.Clear();
            foreach (Order ord in searchResults)
                orders.Add(ord);
            return SearchResult.OK;
        }









        /// <summary>
        /// Валидация ID
        /// </summary>
        /// <param name="idStr">id в виде строки</param>
        /// <param name="id">id</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <returns></returns>
        /// <returns>true, в случае, если значение валидно и false в противном случае</returns>
        protected static bool ValidateID(string idStr, ref int id, ref string errorMessage)
        {
            if (!int.TryParse(idStr, out id))
            {
                errorMessage = "Введенная строка не является числом";
                return false;
            }
            if (id <= 0)
            {
                errorMessage = "Недопустимое значение ID";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация года
        /// </summary>
        /// <param name="yearStr">Год в виде строки</param>
        /// <param name="year">Год (выходной параметр)</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <returns>true, в случае, если значение валидно и false в противном случае</returns>
        private static bool ValidateYear(string yearStr, ref int year, ref string errorMessage)
        {
            if (!int.TryParse(yearStr, out year))
            {
                errorMessage = "Введенная строка не является числом";
                return false;
            }
            if (year<MIN_CAR_YEAR || year>DateTime.Now.Year)
            {
                errorMessage = "Введенный год некорректен. Введите год в диапазоне от " + MIN_CAR_YEAR + " до " + DateTime.Now.Year;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация мощности двигателя
        /// </summary>
        /// <param name="powerStr">мощность в виде строки</param>
        /// <param name="power">мощность</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <returns>true, в случае, если значение валидно и false в противном случае</returns>
        private static bool ValidatePower(string powerStr, ref int power, ref string errorMessage)
        {
            if (!int.TryParse(powerStr, out power))
            {
                errorMessage = "Введенная строка не является числом";
                return false;
            }
            if (power <=0 || power>MAX_ENGINE_POWER)
            {
                errorMessage = "Некорректно задана мощность двигателя";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация даты
        /// </summary>
        /// <param name="dateStr">Дата в виде строки</param>
        /// <param name="date">Дата</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <returns>true, в случае, если значение валидно и false в противном случае</returns>
        private static bool ValidateDate(string dateStr, ref DateTime date, ref string errorMessage)
        {
            if (!DateTime.TryParse(dateStr, out date))
            {
                errorMessage = "Введённая строка не является датой";
                return false;
            }
            if (date > DateTime.Now)
            {
                errorMessage = "Некорректная дата";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация стоимости
        /// </summary>
        /// <param name="dateStr">Стоимость в виде строки</param>
        /// <param name="date">Стоимость</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <returns>true, в случае, если значение валидно и false в противном случае</returns>
        private static bool ValidateCost(string costStr, ref int cost, ref string errorMessage)
        {
            if (!int.TryParse(costStr, out cost))
            {
                errorMessage = "Введенная строка не является числом";
                return false;
            }
            if (cost <= 0 )
            {
                errorMessage = "Стоимость должна быть больше нуля";
                return false;
            }
            return true;
        }
    }
}
