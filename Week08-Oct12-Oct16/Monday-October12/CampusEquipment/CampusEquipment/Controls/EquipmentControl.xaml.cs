using CampusEquipment.Models;
using CampusEquipment.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CampusEquipment.Controls
{
    /// <summary>
    /// Interaction logic for EquipmentControl.xaml
    /// </summary>
    public partial class EquipmentControl : UserControl
    {
        private ObservableCollection<Equipment> equipment;
        public EquipmentControl()
        {
            InitializeComponent();

            equipment = new ObservableCollection<Equipment>();

            EquipmentDataGrid.ItemsSource = equipment;

            //equipment.Add(new Equipment
            //{
            //    AssetNumber = "EQ-101",
            //    EquipmentName = "Canon Printer",
            //    Category = "Printer",
            //    DailyRentalRate = 85.5m,
            //    PurchaseDate = DateTime.Today,
            //    Condition = "Good",
            //    IsAvailable = true

            //});

            //AddEquipmentButton.Click += AddEquipmentButton_Click;
            //AddEquipmentButton.Click += ClickEventRecorded;

            //AddEquipmentButton.Click -= AddEquipmentButton_Click;






        }
        //private void ClickEventRecorded(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Your click has been recorded");
        //}

        private void AddEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
           
            ///We can show that the sender is a Button

            ////if (sender is Button button)
            ////{
            ////    MessageBox.Show(button.Content.ToString());
            ////}


            ///We can also show the information contained in the event like the source and flagging if it is handled or not
            //MessageBox.Show(e.Source.ToString());

            //e.Handled = true;

            //MessageBox.Show(e.Handled.ToString());

            //MessageBox.Show("Add Equipment Button Clicked");

           
            // ============================================================
            // STEP 1: CREATE THE ADD EQUIPMENT WINDOW
            // ============================================================

            AddEquipmentWiindow window =
                new AddEquipmentWiindow();


            // ============================================================
            // STEP 2: OPEN THE WINDOW AS A MODAL DIALOG
            // ============================================================

            // ShowDialog() opens the Add Equipment window.
            //
            // Because this is a modal window, the user must finish
            // working with it before returning to EquipmentControl.
            //
            // ShowDialog() returns:
            //
            // true  -> user successfully completed the dialog
            // false -> user cancelled
            //
            // The AddEquipmentWiindow controls this value using:
            //
            // DialogResult = true;
            //
            // or
            //
            // DialogResult = false;

            bool? result = window.ShowDialog();


            // ============================================================
            // STEP 3: CHECK WHETHER THE USER CLICKED ADD EQUIPMENT
            // ============================================================

            if (result == true)
            {
                // The AddEquipmentWiindow created an Equipment object
                // and stored it in its NewEquipment property.
                //
                // Make sure the object exists before using it.
                if (window.NewEquipment != null)
                {
                    // ====================================================
                    // STEP 4: ADD IT TO THE COLLECTION
                    // ====================================================

                    // Add the Equipment object to our
                    // ObservableCollection<Equipment>.
                    equipment.Add(window.NewEquipment);


                    // THAT'S IT!
                    //
                    // Notice that we do NOT write:
                    //
                    // EquipmentDataGrid.Items.Add(...)
                    //
                    // We change our DATA:
                    //
                    // equipment.Add(...)
                    //
                    // Because EquipmentDataGrid.ItemsSource is connected
                    // to this ObservableCollection, the DataGrid displays
                    // the new Equipment automatically.
                }
            }
        }

    }
}
