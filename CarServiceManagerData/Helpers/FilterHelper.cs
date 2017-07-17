using CarServiceData;
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
        public static void GetAllItemsFromColumn(List<Order> orders, int column, ObservableCollection<object> items)
        {
            IEnumerable<object> itemsToFilter = null;
            switch (column)
            {
                case 0:
                    itemsToFilter = (from order in orders
                                     orderby order.OrderId
                                     select (object)order.OrderId).Distinct();
                    break;
                case 1:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.CarMark.Name
                                     select (object)order.Car.CarMark.Name).Distinct();
                    break;
                case 2:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.Model
                                     select (object)order.Car.Model).Distinct();
                    break;
                case 3:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.Year
                                     select (object)order.Car.Year).Distinct();
                    break;
                case 4:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.TransmissionType
                                     select (object)order.Car.TransmissionType.Name).Distinct();
                    break;
                case 5:
                    itemsToFilter = (from order in orders
                                     orderby order.Car.EnginePower
                                     select (object)order.Car.EnginePower).Distinct();
                    break;
                case 6:
                    itemsToFilter = (from order in orders
                                     orderby order.Work
                                     select (object)order.Work).Distinct();
                    break;
                case 7:
                    itemsToFilter = (from order in orders
                                     orderby order.WorkStart
                                     select (object)order.WorkStart).Distinct();
                    break;
                case 8:
                    itemsToFilter = (from order in orders
                                     orderby order.WorkFinish
                                     select (object)order.WorkFinish).Distinct();
                    break;
                case 9:
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
        public static void FilterCollection (ObservableCollection<Order> orders, int column, object filter)
        {
            List<Order> filteredOrders = null;
            switch (column)
            {
                case 0:
                    filteredOrders = orders.Where(ord => ord.OrderId == (int)filter).ToList();
                    break;
                case 1:
                    filteredOrders = orders.Where(ord => ord.Car.CarMark.Name == (string)filter).ToList();
                    break;
                case 2:
                    filteredOrders = orders.Where(ord => ord.Car.Model == (string)filter).ToList();
                    break;
                case 3:
                    filteredOrders = orders.Where(ord => ord.Car.Year == (int)filter).ToList();
                    break;
                case 4:
                    filteredOrders = orders.Where(ord => ord.Car.TransmissionType.Name == (string)filter).ToList();
                    break;
                case 5:
                    filteredOrders = orders.Where(ord => ord.Car.EnginePower == (int)filter).ToList();
                    break;
                case 6:
                    filteredOrders = orders.Where(ord => ord.Work == (string)filter).ToList();
                    break;
                case 7:
                    filteredOrders = orders.Where(ord => ord.WorkStart == (DateTime)filter).ToList();
                    break;
                case 8:
                    if (filter != null)
                        filteredOrders = orders.Where(ord => ord.WorkFinish == (DateTime)filter).ToList();
                    else
                        filteredOrders = orders.Where(ord => ord.WorkFinish == null).ToList();
                    break;
                case 9:
                    filteredOrders = orders.Where(ord => ord.Cost == (int)filter).ToList();
                    break;
            }
            orders.Clear();
            foreach (Order ord in filteredOrders)
                orders.Add(ord);
        }
    }
}
