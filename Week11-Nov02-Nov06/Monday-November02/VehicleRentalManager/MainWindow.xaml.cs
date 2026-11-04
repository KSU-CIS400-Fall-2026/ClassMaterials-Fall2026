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
using VehicleRentalManager.Models;
using VehicleRentalManager.Controls;

namespace VehicleRentalManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VehicleManager _manager;
        public MainWindow()
        {
            InitializeComponent();

            _manager = new VehicleManager();

            LoadSampleData();

        }

        //Method to load sample data

        private void LoadSampleData()
        {
            Vehicle vehicle1 = new Vehicle
            {
                VehicleNumber = "VEH-001",
                MakeModel = "Toyota Camry",
                DailyRate = 75.00m,
                IsAvailable = true
            };

            Vehicle vehicle2 = new Vehicle
            {
                VehicleNumber = "VEH-002",
                MakeModel = "Honda CR-V",
                DailyRate = 95.00m,
                IsAvailable = false
            };

            Vehicle vehicle3 = new Vehicle
            {
                VehicleNumber = "VEH-003",
                MakeModel = "Ford Explorer",
                DailyRate = 110.00m,
                IsAvailable = false
            };

            Vehicle vehicle4 = new Vehicle
            {
                VehicleNumber = "VEH-004",
                MakeModel = "Nissan Altima",
                DailyRate = 70.00m,
                IsAvailable = true
            };

            _manager.Vehicles.Add(vehicle1);
            _manager.Vehicles.Add(vehicle2);
            _manager.Vehicles.Add(vehicle3);
            _manager.Vehicles.Add(vehicle4);


            _manager.Rentals.Add(new Rental
            {
                RentalNumber = "RENT-001",
                CustomerName = "Jordan Smith",
                Vehicle = vehicle2,
                NumberOfDays = 3,
                AmountPaid = 285.00m
            });

            _manager.Rentals.Add(new Rental
            {
                RentalNumber = "RENT-002",
                CustomerName = "Taylor Brown",
                Vehicle = vehicle3,
                NumberOfDays = 5,
                AmountPaid = 300.00m
            });
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RentalReportControl(_manager);
        }
    }
}