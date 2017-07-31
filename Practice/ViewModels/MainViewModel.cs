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
using CarServiceManagerData.ViewModels;
using CarServiceManagerData.DataControllers;
using Practice.Helpers;

namespace CarServiceData
{
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заказы
        /// </summary>
        public static ObservableCollection<Order> Orders { get; set; }
        /// <summary>
        /// Текущая страница
        /// </summary>
        public static ObservableCollection<Order> CurrentPage { get; set; }
        /// <summary>
        /// Список всех столбцов
        /// </summary>
        public static List<string> Columns { get; set; }
        /// <summary>
        /// Список всех значений для фильтра
        /// </summary>
        public static ObservableCollection<object> ItemsToFilter { get; set; }

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
        /// Команда для поиска
        /// </summary>
        Command search;
        /// <summary>
        /// Команда для перехода к следующей странице
        /// </summary>
        Command toNextPage;
        /// <summary>
        /// Команда для перехода к предыдущей странице
        /// </summary>
        Command toPrevPage;
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
        /// <summary>
        /// Выбранная колонка для поиска
        /// </summary>
        int selectedSearchItem = 0;
        /// <summary>
        /// Количество записей на странице
        /// </summary>
        int recordsPerPage = 10;
        /// <summary>
        /// Текущая запись
        /// </summary>
        int currentPageNum = 1;
        /// <summary>
        /// Всего страниц
        /// </summary>
        int totalPages;

        /// <summary>
        /// Содержимое, которое будем искать
        /// </summary>
        string searchValue = "";
        /// <summary>
        /// производилась ли фильтрация
        /// </summary>
        bool isFiltered = false;
        /// <summary>
        /// производился ли поиск
        /// </summary>
        bool isSearched = false;

        public MainViewModel()
        {
            allOrders = (List<Order>)DataController.GetAllOrders();
            Orders = new ObservableCollection<Order>(allOrders);
            CurrentPage = new ObservableCollection<Order>();
            totalPages = Orders.Count / recordsPerPage + (Orders.Count % recordsPerPage == 0 ? 0 : 1);
            ToFirstPage();
            

            showGraphicWindow = new Command(DoShowDiagramWindow);
            unfilter = new Command(DoUnfilter);
            search = new Command(MakeSearch);
            sortItems = new Command(MakeSort);
            toPrevPage = new Command(GoToPrevPage);
            toNextPage = new Command(GoToNextPage);

            Columns = new List<string> { "ID", "Марка", "Модель", "Год выпуска", "Тип трансмиссии", "Мощность двигателя", "Вид работ",
                "Начало выполнения", "Конец выполнения", "Стоимость" };
            ItemsToFilter = new ObservableCollection<object>();
            FilterHelper.GetAllItemsFromColumn(allOrders, (TableColumns)selectedFilterItem, ItemsToFilter);
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
            DiagramWindow dw = new DiagramWindow(Orders);
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
            isFiltered = false;
            TotalPages = Orders.Count / recordsPerPage + (Orders.Count % recordsPerPage == 0 ? 0 : 1);
            ToFirstPage();
        }

        /// <summary>
        /// Сортировка коллекции
        /// </summary>
        private void MakeSort()
        {
            SortOrder ascending = (SortOrder)SelectedSortRegime;
            switch ((TableColumns)selectedSortItem)
            {
                case TableColumns.ID:
                    SortHelper.SortCollection(Orders, i => i.OrderId, ascending);
                    break;
                case TableColumns.CarMark:
                    SortHelper.SortCollection(Orders, i => i.Car.CarMark.Name, ascending);
                    break;
                case TableColumns.CarModel:
                    SortHelper.SortCollection(Orders, i => i.Car.Model, ascending);
                    break;
                case TableColumns.CarYear:
                    SortHelper.SortCollection(Orders, i => i.Car.Year, ascending);
                    break;
                case TableColumns.CarTransmissionType:
                    SortHelper.SortCollection(Orders, i => i.Car.TransmissionType.Name, ascending);
                    break;
                case TableColumns.CarEnginePower:
                    SortHelper.SortCollection(Orders, i => i.Car.EnginePower, ascending);
                    break;
                case TableColumns.WorkType:
                    SortHelper.SortCollection(Orders, i => i.Work, ascending);
                    break;
                case TableColumns.WorkStart:
                    SortHelper.SortCollection(Orders, i => i.WorkStart, ascending);
                    break;
                case TableColumns.WorkEnd:
                    SortHelper.SortCollection(Orders, i => i.WorkFinish, ascending);
                    break;
                case TableColumns.Cost:
                    SortHelper.SortCollection(Orders, i => i.Cost, ascending);
                    break;
            }
            ToFirstPage();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        private void MakeSearch()
        {
            DoUnfilter();
            string errorMessage = "";
            SearchResult res = SearchHelper.SearchInCollection(Orders, (TableColumns)selectedSearchItem, searchValue.Trim(), ref errorMessage);
            if (res == SearchResult.Error)
                MessageBox.Show(errorMessage);
            else if (res == SearchResult.NothingFound)
                MessageBox.Show("Ничего не найдено");
            else
            {
                isSearched = true;
                TotalPages = Orders.Count / recordsPerPage + (Orders.Count % recordsPerPage == 0 ? 0 : 1);
                ToFirstPage();
            }
        }

        /// <summary>
        /// Возврат на первую страницу
        /// </summary>
        private void ToFirstPage()
        {
            CurrentPage.Clear();
            CurrentPageNum = 1;
            for (int i = 0; i<Orders.Count && i < recordsPerPage; ++i)
                CurrentPage.Add(Orders[i]);
        }
        /// <summary>
        /// Возврат на предыдущую страницу
        /// </summary>
        private void GoToPrevPage()
        {
            if (currentPageNum > 1)
            {
                CurrentPageNum--;
                CurrentPage.Clear();
                for (int i = (currentPageNum-1) * recordsPerPage; i < Orders.Count && i < currentPageNum  * recordsPerPage; ++i)
                    CurrentPage.Add(Orders[i]);
            }
        }
        /// <summary>
        /// На следующую страницу
        /// </summary>
        private void GoToNextPage()
        {
            if(currentPageNum < TotalPages)
            {
                CurrentPageNum++;
                CurrentPage.Clear();
                for (int i = (currentPageNum-1) * recordsPerPage; i < Orders.Count && i < currentPageNum * recordsPerPage; ++i)
                    CurrentPage.Add(Orders[i]);
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
        /// Команда для поиска
        /// </summary>
        public Command SearchItem
        {
            get { return search; }
        }
        /// <summary>
        /// Команда возврата на предыдущую страницу
        /// </summary>
        public Command ToPrevPage
        {
            get { return toPrevPage; }
        }
        /// <summary>
        /// Команда возврата на следующую страницу
        /// </summary>
        public Command ToNextPage
        {
            get { return toNextPage; }
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
                FilterHelper.GetAllItemsFromColumn(allOrders, (TableColumns)selectedFilterItem, ItemsToFilter);
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
                    if ((TableColumns)selectedFilterItem == TableColumns.WorkEnd && ItemsToFilter[SelectedFilterIndex] is string) //отдельно обрабатываем заказы в процессе обработки
                        FilterHelper.FilterCollection(Orders, (TableColumns)selectedFilterItem, null);
                    else 
                        FilterHelper.FilterCollection(Orders, (TableColumns)selectedFilterItem, ItemsToFilter[SelectedFilterIndex]);
                    isFiltered = true;
                    TotalPages = Orders.Count / recordsPerPage + (Orders.Count % recordsPerPage == 0 ? 0 : 1);
                    ToFirstPage();
                }
            }
        }
        /// <summary>
        /// Изменение колноки поиска
        /// </summary>
        public int SelectedSearchItem
        {
            get { return selectedSearchItem; }
            set
            {
                selectedSearchItem = value;
                if (isSearched)
                {
                    DoUnfilter();
                    isSearched = false;
                }
            }
        }
        /// <summary>
        /// Изменение строки, которую мы будем искать
        /// </summary>
        public string SearchValue
        {
            get { return searchValue; }
            set
            {
                searchValue = value;
            }
        }

        /// <summary>
        /// Изменение количества записей на странице
        /// </summary>
        public int RecordsPerPage
        {
            get { return recordsPerPage; }
            set {
                if (value > 0)
                {
                    recordsPerPage = value;
                    TotalPages = Orders.Count / recordsPerPage + (Orders.Count % recordsPerPage == 0 ? 0 : 1);
                    ToFirstPage();
                }
            }
        }
        /// <summary>
        /// номер текущей страницы
        /// </summary>
        public int CurrentPageNum
        {
            get { return currentPageNum; }
            set {
                currentPageNum = value;
                OnPropertyChanged("CurrentPageNum");
            }
        }
        /// <summary>
        /// Общее количество страниц
        /// </summary>
        public int TotalPages
        {
            get { return totalPages; }
            set
            {
                totalPages = value;
                OnPropertyChanged("TotalPages");
            }
        }

    }
}