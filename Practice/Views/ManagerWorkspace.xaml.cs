using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarServiceData;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();

            //using (DBContext db = new DBContext())
            //{
            //    var l = db.Cars.ToList();
            //    db.Orders.Add(new Order { Cost = 1000, CarId = 1, Work = "Замена масла", WorkStart = DateTime.Parse("2017-05-05 20:00:00Z"), WorkFinish = DateTime.Parse("2017-06-06 21:00:00Z") });
            //    db.SaveChanges();
            //}
  //          using (DBContext db = new DBContext())
  //          {
  //              db.Cars.Add(new Car() { CarMarkId=1, EnginePower=200, Model="V12", TypeOfTransmissionId=1, Year=2010})
  //          }
            //using (DBContext db = new DBContext())
            //{
            //    List<CarMark> list = db.CarMarks.ToList();
            //    db.CarMarks.Add(new CarMark() {  Name = "Opel" });
            //    db.CarMarks.Add(new CarMark() {  Name = "Ferrari" });
            //    db.CarMarks.Add(new CarMark() {  Name = "Lada" });
            //    db.CarMarks.Add(new CarMark() {  Name = "Mercedes" });
            //    db.SaveChanges();
            //}
            
        }

        private void btnDigram_Click(object sender, RoutedEventArgs e)
        {
            DiagramWindow dw = new DiagramWindow();
            dw.Owner = this; //Чтобы окно закрывалось при закрытии главной формы
            dw.Show();
        }
    }
}
