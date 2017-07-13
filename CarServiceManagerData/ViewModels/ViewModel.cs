using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceData
{
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заказы
        /// </summary>
        public static ObservableCollection<Order> Orders { get; set; }

        public ViewModel()
        {
            using (DBContext dbContext = new DBContext())
            {
                //Конвертация в ObservableCollection
                Orders = new ObservableCollection<Order>(dbContext.Orders);
                var l = dbContext.CarMarks.ToList();
                var m = dbContext.Cars.ToList();
                var a = dbContext.TransmissionTypes.ToList();
            }
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
    }
}
