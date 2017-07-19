using CarServiceData;
using CarServiceManagerData.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagerData.Helpers
{
    public class FilterHelper
    {
        /// <summary>
        /// получение всех элементов заданного столбца из таблицы
        /// </summary>
        /// <param name="orders">Таблица заказов</param>
        /// <param name="column">Номер столбца</param>
        /// <param name="items">Список, отображающий все возможные значения</param>
        public static void GetAllItemsFromColumn(List<Order> orders, TableColumns column, ObservableCollection<object> items)
        {
            IEnumerable<object> itemsToFilter = null;
            switch (column)
            {
                case TableColumns.ID:
                    itemsToFilter = (from order in orders
                                     orderby order.OrderId
                                     select (object)order.OrderId).Distinct();
                    break;
                case TableColumns.CarMark:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.CarMark.Name
                                     select (object)order.Car.CarMark.Name).Distinct();
                    break;
                case TableColumns.CarModel:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.Model
                                     select (object)order.Car.Model).Distinct();
                    break;
                case TableColumns.CarYear:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.Year
                                     select (object)order.Car.Year).Distinct();
                    break;
                case TableColumns.CarTransmissionType:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.TransmissionType
                                     select (object)order.Car.TransmissionType.Name).Distinct();
                    break;
                case TableColumns.CarEnginePower:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.EnginePower
                                     select (object)order.Car.EnginePower).Distinct();
                    break;
                case TableColumns.WorkType:
                    itemsToFilter = (from order in orders
                                     orderby order.Work
                                     select (object)order.Work).Distinct();
                    break;
                case TableColumns.WorkStart:
                    itemsToFilter = (from order in orders
                                     orderby order.WorkStart
                                     select (object)order.WorkStart).Distinct();
                    break;
                case TableColumns.WorkEnd:
                    itemsToFilter = (from order in orders
                                     orderby order.WorkFinish
                                     select (object)order.WorkFinish).Distinct();
                    break;
                case TableColumns.Cost:
                    itemsToFilter = (from order in orders
                                     orderby order.Cost
                                     select (object)order.Cost).Distinct();
                    break;
            }
            items.Clear();
            foreach (object obj in itemsToFilter)
                items.Add(obj);
        }

        /// <summary>
        /// Фильтрация в коллекции всех элементов, равных заданному
        /// </summary>
        /// <param name="orders">Коллекция</param>
        /// <param name="column">Столбец</param>
        /// <param name="filter">заданный элемент</param>
        public static void FilterCollection (ObservableCollection<Order> orders, TableColumns column, object filter)
        {
            List<Order> filteredOrders = null;
            switch (column)
            {
                case TableColumns.ID:
                    filteredOrders = orders.Where(ord => ord.OrderId == (int)filter).ToList();
                    break;
                case TableColumns.CarMark:
                    filteredOrders = orders.Where(ord => ord.Car.CarMark.Name == (string)filter).ToList();
                    break;
                case TableColumns.CarModel:
                    filteredOrders = orders.Where(ord => ord.Car.Model == (string)filter).ToList();
                    break;
                case TableColumns.CarYear:
                    filteredOrders = orders.Where(ord => ord.Car.Year == (int)filter).ToList();
                    break;
                case TableColumns.CarTransmissionType:
                    filteredOrders = orders.Where(ord => ord.Car.TransmissionType.Name == (string)filter).ToList();
                    break;
                case TableColumns.CarEnginePower:
                    filteredOrders = orders.Where(ord => ord.Car.EnginePower == (int)filter).ToList();
                    break;
                case TableColumns.WorkType:
                    filteredOrders = orders.Where(ord => ord.Work == (string)filter).ToList();
                    break;
                case TableColumns.WorkStart:
                    filteredOrders = orders.Where(ord => ord.WorkStart == (DateTime)filter).ToList();
                    break;
                case TableColumns.WorkEnd:
                    if (filter != null)
                        filteredOrders = orders.Where(ord => ord.WorkFinish == (DateTime)filter).ToList();
                    else
                        filteredOrders = orders.Where(ord => ord.WorkFinish == null).ToList();
                    break;
                case TableColumns.Cost:
                    filteredOrders = orders.Where(ord => ord.Cost == (int)filter).ToList();
                    break;
            }
            orders.Clear();
            foreach (Order ord in filteredOrders)
                orders.Add(ord);
        }
    }
}
