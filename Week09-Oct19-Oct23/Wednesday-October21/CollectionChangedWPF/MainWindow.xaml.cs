using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace CollectionChangedWPF
{
    public partial class MainWindow : Window
    {
        // ============================================================
        // OBSERVABLE COLLECTION
        // ============================================================

        // This collection stores all of our Equipment objects.
        //
        // We use ObservableCollection<Equipment> instead of
        // List<Equipment> because ObservableCollection can notify
        // listeners when items are:
        //
        //      Added
        //      Removed
        //      Replaced
        //      Moved
        //      Cleared
        //
        // WPF controls such as DataGrid, ListBox and ComboBox know
        // how to listen for these collection-change notifications.

        private ObservableCollection<Equipment> equipment =
            new ObservableCollection<Equipment>();


        public MainWindow()
        {
            InitializeComponent();


            // ========================================================
            // ADD SOME STARTING EQUIPMENT
            // ========================================================

            equipment.Add(new Equipment
            {
                AssetNumber = "EQ-1001",
                EquipmentName = "Canon Camera",
                Category = "Camera",
                DailyRentalRate = 18.50m
            });


            equipment.Add(new Equipment
            {
                AssetNumber = "EQ-1002",
                EquipmentName = "Dell Laptop",
                Category = "Laptop",
                DailyRentalRate = 25.00m
            });


            equipment.Add(new Equipment
            {
                AssetNumber = "EQ-1003",
                EquipmentName = "Epson Projector",
                Category = "Projector",
                DailyRentalRate = 15.00m
            });


            // ========================================================
            // CONNECT THE COLLECTION TO THE DATAGRID
            // ========================================================

            // ItemsSource tells the DataGrid:
            //
            // "This is the collection of objects you should display."
            //
            // The DataGrid now displays the Equipment objects stored
            // inside our ObservableCollection.

            EquipmentDataGrid.ItemsSource = equipment;


            // ========================================================
            // LISTEN TO COLLECTIONCHANGED OURSELVES
            // ========================================================

            // WPF already knows how to listen to ObservableCollection.
            //
            // But we can ALSO subscribe to the CollectionChanged event
            // ourselves if our application needs to perform additional
            // work whenever the collection changes.

            equipment.CollectionChanged += Equipment_CollectionChanged;
        }


        // ============================================================
        // ADD EQUIPMENT
        // ============================================================

        private void AddEquipment_Click( object sender, RoutedEventArgs e)
        {
            // Create a new Equipment object.
            Equipment newEquipment = new Equipment
            {
                AssetNumber = $"EQ-{1000 + equipment.Count + 1}",
                EquipmentName = "New Equipment",
                Category = "Other",
                DailyRentalRate = 10.00m
            };


            // Add the new object to the ObservableCollection.
            //
            // IMPORTANT:
            //
            // We are NOT directly adding a row to the DataGrid.
            //
            // We change the DATA.
            //
            // ObservableCollection tells WPF:
            //
            //      "Hey! My collection changed."
            //
            // WPF then updates the DataGrid automatically.

            equipment.Add(newEquipment);
        }


        // ============================================================
        // REMOVE EQUIPMENT
        // ============================================================

        private void RemoveEquipment_Click(
            object sender,
            RoutedEventArgs e)
        {
            // SelectedItem gives us the object represented by the
            // currently selected DataGrid row.

            Equipment? selectedEquipment =
                EquipmentDataGrid.SelectedItem as Equipment;


            // Make sure the user actually selected something.
            if (selectedEquipment == null)
            {
                MessageBox.Show(
                    "Please select equipment to remove.");

                return;
            }


            // Remove the object from our DATA collection.
            //
            // Again, notice:
            //
            // We do NOT manually remove the row from the DataGrid.
            //
            // We remove the Equipment object from the
            // ObservableCollection.

            equipment.Remove(selectedEquipment);


            // CollectionChanged fires.
            //
            // WPF hears the notification.
            //
            // WPF removes the corresponding row automatically.
        }


        // ============================================================
        // CLEAR EQUIPMENT
        // ============================================================

        private void ClearEquipment_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Remove everything from the ObservableCollection.
            equipment.Clear();


            // This normally raises:
            //
            // NotifyCollectionChangedAction.Reset
            //
            // The DataGrid automatically becomes empty.
        }


        // ============================================================
        // COLLECTIONCHANGED EVENT HANDLER
        // ============================================================

        private void Equipment_CollectionChanged(
            object? sender,
            NotifyCollectionChangedEventArgs e)
        {
            // This is the SAME CollectionChanged event that we used
            // in our Console application.
            //
            // WPF does not change how ObservableCollection works.
            //
            // The important difference is that WPF controls can
            // automatically listen to these notifications.


            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Get the newly added Equipment object.
                Equipment addedEquipment =
                    (Equipment)e.NewItems![0]!;

                MessageBox.Show(
                    $"Collection changed!\n\n" +
                    $"Action: {e.Action}\n" +
                    $"Added: {addedEquipment.EquipmentName}");
            }


            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                // Get the Equipment object that was removed.
                Equipment removedEquipment =
                    (Equipment)e.OldItems![0]!;

                MessageBox.Show(
                    $"Collection changed!\n\n" +
                    $"Action: {e.Action}\n" +
                    $"Removed: {removedEquipment.EquipmentName}");
            }


            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                MessageBox.Show(
                    "Collection changed!\n\n" +
                    "Action: Reset\n" +
                    "The collection was cleared.");
            }
        }
    }
}