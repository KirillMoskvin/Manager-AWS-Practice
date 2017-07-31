using CarServiceData;
using Practice.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practice.ViewModels
{
    /// <summary>
    /// Виды статистики
    /// </summary>
    enum StatType
    {
        CarMarks=0,
        OrdersPerMonth = 1,
        OrderPrices = 2
    }
    /// <summary>
    /// Вид графика
    /// </summary>
    enum ChartType
    {
        Column=0,
        Pie = 1,
        Line = 2
    }

    class StatisticsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заказы
        /// </summary>
        public ObservableCollection<Order> Orders { get; set;}
        /// <summary>
        /// Отображаемая статистика
        /// </summary>
        public ObservableCollection<KeyValuePair<string, int>> Stats { get; set; }
        /// <summary>
        /// Статистика по маркам
        /// </summary>
        private Dictionary<string, int> markStats;
        /// <summary>
        /// Статистика по месяцам
        /// </summary>
        private List<int> orderMonthCount;
        /// <summary>
        /// Статистика по ценам
        /// </summary>
        private List<int> priceStats;
        /// <summary>
        /// Выбранный тип статистики
        /// </summary>
        private int selectedStatIndex=-1;
        /// <summary>
        /// Ценовые категории
        /// </summary>
        decimal[] priceCategories = new decimal[10] { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };
        /// <summary>
        /// Видимость столбчатой диаграммы
        /// </summary>
        Visibility columnVisible = Visibility.Collapsed;
        /// <summary>
        /// Видимость круговой диаграммы
        /// </summary>
        Visibility pieVisible = Visibility.Collapsed;
        /// <summary>
        /// Видимость линейной диаграммы
        /// </summary>
        Visibility lineVisible = Visibility.Visible;
        /// <summary>
        /// Выбранный тип графика
        /// </summary>
        int selectedChartType;


        public StatisticsViewModel (ObservableCollection<Order> orders)
        {
            this.Orders = orders;

            markStats = new Dictionary<string, int>();
            orderMonthCount = new List<int>();
            priceStats = new List<int>();

            Stats = new ObservableCollection<KeyValuePair<string, int>>();
            FormStatsMarks();
            FormStatsMonth();
            FormStatsPrices();
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
        /// Формирование статистики по маркам автомобилей
        /// </summary>
        protected void FormStatsMarks()
        {
            foreach (Order ord in Orders)
                if (markStats.Keys.Contains(ord.Car.CarMark.Name))
                    markStats[ord.Car.CarMark.Name]++;
                else
                    markStats[ord.Car.CarMark.Name] = 1;
        }
        /// <summary>
        /// Установка статистики по маркам
        /// </summary>
        protected void SetStatsToMarks()
        {
            Stats.Clear();
            foreach (var pair in markStats)
                Stats.Add(pair);
        }

        /// <summary>
        /// Формирование статистики заказов по месяцам
        /// </summary>
        protected void FormStatsMonth()
        {
            for (int i = 0; i < 12; i++)
                orderMonthCount.Add(0);

            foreach (Order ord in Orders)
                if (ord.WorkStart.Year == DateTime.Now.Year)
                    orderMonthCount[ord.WorkStart.Month-1]++;
        }
        /// <summary>
        /// Установка статистики по месяцам
        /// </summary>
        protected void SetStatstoMonth()
        {
            Stats.Clear();
            for (int i = 1; i <= DateTime.Now.Month; ++i)
                Stats.Add(new KeyValuePair<string, int>(MonthToStringConverter.Convert(i), orderMonthCount[i - 1]));
        }
        /// <summary>
        /// Формирование статистики заказов по ценовым категориям
        /// </summary>
        public void FormStatsPrices()
        {
            priceStats.Clear();
            for (int i = 0; i <= priceCategories.Length; ++i)
                priceStats.Add(0);

            foreach (Order ord in Orders)
            {
                bool added = false;
                for (int i = 0; i < priceCategories.Length && !added; ++i)
                    if (ord.Cost < priceCategories[i])
                    {
                        priceStats[i]++;
                        added = true;
                    }
                if (!added)
                    priceStats[priceCategories.Length]++;
            }
        }
        /// <summary>
        /// Установка статистики по ценам
        /// </summary>
        protected void SetStatsPrices()
        {
            Stats.Clear();
            Stats.Add(new KeyValuePair<string, int>("0-" + priceCategories[0].ToString(), priceStats[0]));
            for (int i = 1; i < priceStats.Count - 1; ++i)
                Stats.Add(new KeyValuePair<string, int>(priceCategories[i - 1].ToString() + "-" + priceCategories[i].ToString(), priceStats[i]));
            Stats.Add(new KeyValuePair<string, int>(priceCategories[priceCategories.Length - 1].ToString() + "+", priceStats.Last()));
        }
        /// <summary>
        /// Свойство выбранного типа статистики
        /// </summary>
        public int SelectedStatIndex
        {
            get { return selectedStatIndex; }
            set
            {
                switch ((StatType)value)
                {
                    case StatType.CarMarks:
                        SetStatsToMarks();
                        break;
                    case StatType.OrderPrices:
                        SetStatsPrices();
                        break;
                    case StatType.OrdersPerMonth:
                        SetStatstoMonth();
                        break;
                }
                selectedStatIndex = value;
            }
        }
        /// <summary>
        /// Видимость столбчатой диаграммы
        /// </summary>
        public Visibility ColumnVisible
        {
            get { return columnVisible; }
            set
            {
                columnVisible = value;
                OnPropertyChanged("ColumnVisible");
            }
        }
        /// <summary>
        /// Видимость круговой диаграммы
        /// </summary>
        public Visibility PieVisible
        {
            get { return pieVisible; }
            set
            {
                pieVisible = value;
                OnPropertyChanged("PieVisible");
            }
        }
        /// <summary>
        /// Видимость линейной диаграммы
        /// </summary>
        public Visibility LineVisible
        {
            get { return lineVisible; }
            set
            {
                lineVisible = value;
                OnPropertyChanged("LineVisible");
            }
        }
        /// <summary>
        /// Выбранный тип графика
        /// </summary>
        public int SelectedChartType
        {
            get { return selectedChartType; }
            set
            {
                switch ((ChartType)value)
                {
                    case ChartType.Column:
                        ColumnVisible = Visibility.Visible;
                        PieVisible = Visibility.Collapsed;
                        LineVisible = Visibility.Collapsed;
                        break;
                    case ChartType.Pie:
                        ColumnVisible = Visibility.Collapsed;
                        PieVisible = Visibility.Visible;
                        LineVisible = Visibility.Collapsed;
                        break;
                    case ChartType.Line:
                        ColumnVisible = Visibility.Collapsed;
                        PieVisible = Visibility.Collapsed;
                        LineVisible = Visibility.Visible;
                        break;
                }
                selectedChartType = value;
            }
        }
    }
}
