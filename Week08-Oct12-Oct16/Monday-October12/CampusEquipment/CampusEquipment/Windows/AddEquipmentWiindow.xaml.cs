using CampusEquipment.Enums;
using CampusEquipment.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CampusEquipment.Windows
{
    /// <summary>
    /// Interaction logic for AddEquipmentWiindow.xaml
    ///
    /// This window allows the user to enter information
    /// for a new piece of equipment.
    /// </summary>
    public partial class AddEquipmentWiindow : Window
    {
        // ============================================================
        // PROPERTY USED TO RETURN THE NEW EQUIPMENT
        // ============================================================

        // This property will store the Equipment object that we create.
        //
        // EquipmentControl will be able to access this property
        // after the window closes.
        //
        // It starts as null because no Equipment object has been
        // created yet.
        public Equipment? NewEquipment { get; private set; }


        public AddEquipmentWiindow()
        {
            InitializeComponent();


            // ========================================================
            // POPULATE THE CATEGORY COMBOBOX
            // ========================================================

            // EquipmentCategory is an enum:
            //
            // Laptop
            // Camera
            // Projector
            // Microphone
            // Tablet
            //
            // Enum.GetValues() gets all of those enum values.
            //
            // ItemsSource tells the ComboBox which items it
            // should display.
            CategoryComboBox.ItemsSource =
                Enum.GetValues(typeof(EquipmentCategory));


            // Select the first category by default.
            CategoryComboBox.SelectedIndex = 0;


            // Select today's date by default.
            PurchaseDatePicker.SelectedDate = DateTime.Today;
        }


        // ============================================================
        // ADD EQUIPMENT BUTTON CLICK EVENT
        // ============================================================

        private void AddEquipmentButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            // ========================================================
            // STEP 1: READ THE INFORMATION FROM THE CONTROLS
            // ========================================================

            // TextBox.Text gives us the text entered by the user.
            string assetNumber =
                AssetNumberTextBox.Text;

            string equipmentName =
                EquipmentNameTextBox.Text;


            // ========================================================
            // STEP 2: SIMPLE VALIDATION
            // ========================================================

            // Make sure an Asset Number was entered.
            if (string.IsNullOrWhiteSpace(assetNumber))
            {
                MessageBox.Show(
                    "Please enter an asset number.");

                return;
            }


            // Make sure an Equipment Name was entered.
            if (string.IsNullOrWhiteSpace(equipmentName))
            {
                MessageBox.Show(
                    "Please enter an equipment name.");

                return;
            }


            // TryParse attempts to convert the text entered into
            // the Daily Rate TextBox into a decimal.
            //
            // If the conversion works:
            //      dailyRate contains the number.
            //
            // If it fails:
            //      TryParse returns false.
            if (!decimal.TryParse(
                DailyRateTextBox.Text,
                out decimal dailyRate))
            {
                MessageBox.Show(
                    "Please enter a valid daily rental rate.");

                return;
            }


            // Make sure the user selected a category.
            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select an equipment category.");

                return;
            }


            // Make sure a purchase date was selected.
            if (PurchaseDatePicker.SelectedDate == null)
            {
                MessageBox.Show(
                    "Please select a purchase date.");

                return;
            }


            // Make sure a condition was selected.
            if (ConditionComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select the equipment condition.");

                return;
            }


            // ========================================================
            // STEP 3: GET THE SELECTED CATEGORY
            // ========================================================

            // Because CategoryComboBox.ItemsSource contains
            // EquipmentCategory enum values, SelectedItem is
            // actually an EquipmentCategory value.
            EquipmentCategory category =
                (EquipmentCategory)CategoryComboBox.SelectedItem;


            // ========================================================
            // STEP 4: GET THE SELECTED CONDITION
            // ========================================================

            // ConditionComboBox is currently using ComboBoxItem
            // objects directly in the XAML.
            //
            // Therefore SelectedItem gives us a ComboBoxItem.
            ComboBoxItem selectedCondition =
                (ComboBoxItem)ConditionComboBox.SelectedItem;


            // Content contains the actual text displayed by
            // the ComboBoxItem.
            string condition =
                selectedCondition.Content.ToString() ?? "";


            // ========================================================
            // STEP 5: GET THE CHECKBOX VALUE
            // ========================================================

            // IsChecked is a nullable bool (bool?).
            //
            // It can technically be:
            //
            // true
            // false
            // null
            //
            // "== true" gives us a normal bool.
            bool isAvailable =
                AvailableCheckBox.IsChecked == true;


            // ========================================================
            // STEP 6: CREATE THE EQUIPMENT OBJECT
            // ========================================================

            // Now we take all the information from the UI
            // and use it to create ONE Equipment object.
            NewEquipment = new Equipment
            {
                AssetNumber = assetNumber,

                EquipmentName = equipmentName,

                Category = category,

                DailyRentalRate = dailyRate,

                PurchaseDate =
                    PurchaseDatePicker.SelectedDate.Value,

                Condition = condition,

                IsAvailable = isAvailable
            };


            // ========================================================
            // STEP 7: CLOSE THE WINDOW SUCCESSFULLY
            // ========================================================

            // DialogResult tells the window that the user
            // successfully completed the dialog.
            //
            // Because EquipmentControl opened this window using
            // ShowDialog(), ShowDialog() will now return true.
            DialogResult = true;


            // Setting DialogResult automatically closes a modal
            // window, so we do not need:
            //
            // Close();
        }


        // ============================================================
        // CANCEL BUTTON CLICK EVENT
        // ============================================================

        private void CancelButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            // The user cancelled the operation.
            //
            // No Equipment object should be added.
            DialogResult = false;


            // Again, setting DialogResult closes the modal window.
        }
    }
}