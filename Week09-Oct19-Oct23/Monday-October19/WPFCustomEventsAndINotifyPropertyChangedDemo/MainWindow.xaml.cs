using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFEventsDemo.Classes;

namespace WPFEventsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EquipmentManager manager = new EquipmentManager();

        private Equipment _item;
        public MainWindow()
        {
            InitializeComponent();

            manager.EquipmentAdded += Manager_Event;
            manager.AddEquipment();


            _item = new Equipment { 
             Name = "InkJet Printer",
             Category = "Printer",
             Quantity = 50
            
            };

            DataContext = _item;
           

        }

        //private void AddEquipment_Click(object sender, RoutedEventArgs e)
        //{La
        //    MessageBox.Show("Add Equipment Button Clicked");
        //}

        public void Manager_Event(object? sender, EventArgs e)
        {
            MessageBox.Show("An equipment has been added!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _item.Name = "Dell";
            _item.Category = "Laptop";
            _item.Quantity = 1000;

        }
    }
}