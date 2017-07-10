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
            using (DBContext db = new DBContext())
            {
                List<CarMark> list = db.CarMarks.ToList();
                db.CarMarks.Add(new CarMark() {  Name = "Opel" });
                db.CarMarks.Add(new CarMark() {  Name = "Ferrari" });
                db.CarMarks.Add(new CarMark() {  Name = "Lada" });
                db.CarMarks.Add(new CarMark() {  Name = "Mercedes" });
                db.SaveChanges();
            }
            
        }

        private void btnDigram_Click(object sender, RoutedEventArgs e)
        {
            DiagramWindow dw = new DiagramWindow();
            dw.Owner = this; //Чтобы окно закрывалось при закрытии главной формы
            dw.Show();
        }
    }
}
