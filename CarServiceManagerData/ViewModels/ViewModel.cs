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

namespace CarServiceData
{
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заказы
        /// </summary>
        public static ObservableCollection<Order> Orders { get; set; }

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
        /// Выбранный критерий сортировки
        /// </summary>
        int selectedSortItem = 0;
        /// <summary>
        /// Выбранный режим сортировки
        /// </summary>
        int selectedSortRegime = 0;

        public ViewModel()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                dbContext.Configuration.ProxyCreationEnabled = true;
                dbContext.Configuration.LazyLoadingEnabled = true;
                dbContext.Configuration.AutoDetectChangesEnabled = true;
                Orders = new ObservableCollection<Order>(dbContext.Orders.Include("Car").Include("Car.TransmissionType").Include("Car.CarMark"));
            }
            showGraphicWindow = new Command(DoShowDiagramWindow);
            sortItems = new Command(MakeSort);
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

    }
}