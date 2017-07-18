using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarServiceManagerData;
using CarServiceData;
using Practice;
using Apex.MVVM;
using CarServiceManagerData.Helpers;
using System.Windows;

namespace CarServiceData
{
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заказы
        /// </summary>
        public static ObservableCollection<Order> Orders { get; set; }
        /// <summary>
        /// Список всех столбцов
        /// </summary>
        public static List<string> Columns { get; set; }
        /// <summary>
        /// Список всех значений для фильтра
        /// </summary>
        public static ObservableCollection<object> ItemsToFilter { get; set; }

        public static Order HoveredRow { get; set; }
        /// <summary>
        /// Все заказы
        /// </summary>
        private List<Order> allOrders;
        /// <summary>
        /// команда для показа окна статистики
        /// </summary>
        /// <returns></returns>
        Command showGraphicWindow;
        /// <summary>
        /// Команда для сортировки списка
        /// </summary>
        Command sortItems;
        /// <summary>
        /// Команда для отмены фильтрации
        /// </summary>
        Command unfilter;
        /// <summary>
        /// Выбранный критерий сортировки
        /// </summary>
        int selectedSortItem = 0;
        /// <summary>
        /// Выбранный режим сортировки
        /// </summary>
        int selectedSortRegime = 0;
        /// <summary>
        /// Выбранный критерий фильтрации
        /// </summary>
        int selectedFilterItem = 0;
        /// <summary>
        /// Выбранный элемент для фильтрации
        /// </summary>
        int selectedFilterIndex = -1;

        public ViewModel()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                allOrders = (dbContext.Orders.Include("Car").Include("Car.TransmissionType").Include("Car.CarMark")).ToList();
                Orders = new ObservableCollection<Order>(allOrders);
            }
            showGraphicWindow = new Command(DoShowDiagramWindow);
            unfilter = new Command(DoUnfilter);

            sortItems = new Command(MakeSort);
            Columns = new List<string> { "ID", "Марка", "Модель", "Год выпуска", "Тип трансмиссии", "Мощность двигателя", "Вид работ",
                "Начало выполнения", "Конец выполнения", "Стоимость" };
            ItemsToFilter = new ObservableCollection<object>();
            FilterHelper.GetAllItemsFromColumn(allOrders, selectedFilterItem, ItemsToFilter);
        }

        /// <summary>
        /// Реализация INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Отображение окна диаграмм
        /// </summary>
        /// <param name="owner"></param>
        private void DoShowDiagramWindow(object owner)
        {
            DiagramWindow dw = new DiagramWindow();
            dw.Owner = (System.Windows.Window)owner; //Чтобы окно закрывалось при закрытии главной формы
            dw.Show();
        }
        /// <summary>
        /// Отмена фильтрации
        /// </summary>
        private void DoUnfilter()
        {
            Orders.Clear();
            foreach (Order ord in allOrders)
                Orders.Add(ord);
        }

        /// <summary>
        /// Сортировка коллекции
        /// </summary>
        private void MakeSort()
        {
            bool ascending = SelectedSortRegime == 0;
            switch (selectedSortItem)
            {
                case 0:
                    SortHelper.SortCollection(Orders, i => i.OrderId, ascending);
                    break;
                case 1:
                    SortHelper.SortCollection(Orders, i => i.Car.CarMark.Name, ascending);
                    break;
                case 2:
                    SortHelper.SortCollection(Orders, i => i.Car.Model, ascending);
                    break;
                case 3:
                    SortHelper.SortCollection(Orders, i => i.Car.Year, ascending);
                    break;
                case 4:
                    SortHelper.SortCollection(Orders, i => i.Car.TransmissionType.Name, ascending);
                    break;
                case 5:
                    SortHelper.SortCollection(Orders, i => i.Car.EnginePower, ascending);
                    break;
                case 6:
                    SortHelper.SortCollection(Orders, i => i.Work, ascending);
                    break;
                case 7:
                    SortHelper.SortCollection(Orders, i => i.WorkStart, ascending);
                    break;
                case 8:
                    SortHelper.SortCollection(Orders, i => i.WorkFinish, ascending);
                    break;
                case 9:
                    SortHelper.SortCollection(Orders, i => i.Cost, ascending);
                    break;
            }
        }

        /// <summary>
        /// свойство для отображения окна диаграмм
        /// </summary>
        public Command ShowDiagramWindow
        {
            get { return showGraphicWindow; }
        }
        /// <summary>
        /// Свойство выбранного элемента для сортировки
        /// </summary>
        public int SelectedSortItem
        {
            get { return selectedSortItem; }
            set {
                selectedSortItem = value;
                MakeSort();
            }
        }
        /// <summary>
        /// Cвойство выбранного режима сортировки
        /// </summary>
        public int SelectedSortRegime
        {
            get { return selectedSortRegime; }
            set {
                selectedSortRegime = value;
                MakeSort();
            }
        }
        /// <summary>
        /// команда для сортировки элементов
        /// </summary>
        public Command SortItems
        {
            get { return sortItems; }
        }
        /// <summary>
        /// Команда для отмены фильтрации 
        /// </summary>
        public Command Unfilter
        {
            get { return unfilter; }
        }
        /// <summary>
        /// Свойство для изменения критерия филтрации
        /// </summary>
        public int SelectedFilterItem
        {
            get { return selectedFilterItem; }
            set {
                selectedFilterItem = value;
                SelectedFilterIndex = -1;
                //обновляем все значения фильтра
                FilterHelper.GetAllItemsFromColumn(allOrders, selectedFilterItem, ItemsToFilter);
                if (selectedFilterItem== 8)
                    ItemsToFilter.Add("В процессе");
            }
        }
        /// <summary>
        /// Изменения фильтра
        /// </summary>
        public int SelectedFilterIndex
        {
            get { return selectedFilterIndex; }
            set {
                selectedFilterIndex = value;

                if (selectedFilterIndex >= 0)
                {
                    DoUnfilter();
                    if (selectedFilterItem == 8 && ItemsToFilter[SelectedFilterIndex] is string) //отдельно обрабатываем заказы в процессе обработки
                        FilterHelper.FilterCollection(Orders, selectedFilterItem, null);
                    else 
                        FilterHelper.FilterCollection(Orders, selectedFilterItem, ItemsToFilter[SelectedFilterIndex]);
                }

            }
        }

    }
}