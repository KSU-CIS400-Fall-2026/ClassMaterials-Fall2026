using EquipmentRentalManager.Controls;
using EquipmentRentalManager.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace EquipmentRentalManager
{
    /// <summary>
    /// MainWindow is the outer shell of the application.
    ///
    /// For this demo, MainWindow is responsible for:
    /// 1. Creating the shared ObservableCollection of Equipment objects.
    /// 2. Adding sample Equipment objects so we have data to work with.
    /// 3. Creating EquipmentControl and passing the SAME collection to it.
    /// 4. Displaying EquipmentControl inside MainContent.
    /// </summary>
    public partial class MainWindow : Window
    {
        // ObservableCollection<T> is useful for collections displayed in WPF.
        // If an Equipment object is ADDED to or REMOVED from this collection,
        // controls bound to the collection can automatically notice that
        // collection-level change.
        //
        // Important:
        // ObservableCollection handles collection changes (add/remove).
        // INotifyPropertyChanged handles property changes inside one Equipment object.
        public ObservableCollection<Equipment> EquipmentItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // STEP 1: Create the collection that will hold all Equipment objects.
            EquipmentItems = new ObservableCollection<Equipment>();

            // STEP 2: Add sample data.
            // These objects give us something to display, select, edit,
            // delete, and retire while learning the WPF concepts.
            EquipmentItems.Add(new Equipment
            {
                AssetNumber = "EQ1001",
                EquipmentName = "Dell Laptop",
                Category = EquipmentCategory.Laptop,
                DailyRentalRate = 25.00m,
                Condition = EquipmentCondition.Good,
                Status = EquipmentStatus.Available
            });

            EquipmentItems.Add(new Equipment
            {
                AssetNumber = "EQ1002",
                EquipmentName = "Canon Camera",
                Category = EquipmentCategory.Camera,
                DailyRentalRate = 18.50m,
                Condition = EquipmentCondition.Good,
                Status = EquipmentStatus.Available
            });

            EquipmentItems.Add(new Equipment
            {
                AssetNumber = "EQ1003",
                EquipmentName = "Epson Projector",
                Category = EquipmentCategory.Projector,
                DailyRentalRate = 30.00m,
                Condition = EquipmentCondition.Fair,
                Status = EquipmentStatus.Maintenance
            });

            // STEP 3: Create the EquipmentControl.
            // Notice that we PASS EquipmentItems into its constructor.
            // We are not creating a second collection inside EquipmentControl.
            // MainWindow and EquipmentControl therefore work with the same data.
            EquipmentControl equipmentControl =
                new EquipmentControl(EquipmentItems);

            // STEP 4: Put EquipmentControl inside the ContentControl named MainContent.
            // Creating a UserControl does not automatically display it.
            // Assigning it to MainContent.Content is what makes it appear.
            MainContent.Content = equipmentControl;
        }
    }
}
