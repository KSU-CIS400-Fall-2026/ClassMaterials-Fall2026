using EquipmentRentalManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EquipmentRentalManager.Controls
{
    /// <summary>
    /// Displays and manages the Equipment collection.
    ///
    /// This control demonstrates several important WPF ideas:
    /// - ObservableCollection<T> for add/remove collection notifications.
    /// - DataGrid.SelectedItem for working with the selected object.
    /// - DataContext for giving the edit control the selected object.
    /// - Control swapping with Visibility.
    /// - Custom child-to-parent events for Save and Back.
    /// - INotifyPropertyChanged for edits/state changes inside Equipment.
    /// </summary>
    public partial class EquipmentControl : UserControl
    {
        // Keep a reference to the SAME collection that MainWindow created.
        // We do not create a second collection here.
        private readonly ObservableCollection<Equipment> _equipmentItems;

        /// <summary>
        /// MainWindow passes its EquipmentItems collection into this constructor.
        /// </summary>
        public EquipmentControl(ObservableCollection<Equipment> equipmentItems)
        {
            InitializeComponent();

            // Store the collection so our Delete handler can remove objects from it.
            _equipmentItems = equipmentItems;

            // Tell the DataGrid which collection it should display.
            EquipmentDataGrid.ItemsSource = _equipmentItems;

            // SUBSCRIBE to the custom events raised by EquipmentEditControl.
            //
            // Read this as:
            // "When EquipmentEditor raises SaveRequested, run
            //  EquipmentEditor_SaveRequested."
            EquipmentEditor.SaveRequested += EquipmentEditor_SaveRequested;

            // "When EquipmentEditor raises BackRequested, run
            //  EquipmentEditor_BackRequested."
            EquipmentEditor.BackRequested += EquipmentEditor_BackRequested;
        }

        /// <summary>
        /// Placeholder for a future Add Equipment lesson.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Equipment can be implemented as the next extension of this demo.");
        }

        /// <summary>
        /// Opens the selected EXISTING Equipment object in EquipmentEditControl.
        /// </summary>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // SelectedItem represents the entire object behind the selected row.
            // If nothing is selected, SelectedItem will not be an Equipment object.
            if (EquipmentDataGrid.SelectedItem is not Equipment selectedEquipment)
            {
                MessageBox.Show("Please select equipment first.");
                return; // Stop this method. There is nothing to edit.
            }

            // THIS IS THE KEY EDITING LINE.
            //
            // We give the editor the SAME Equipment object selected in the DataGrid.
            // We do NOT create a second Equipment object and we do NOT manually copy
            // values into every TextBox.
            //
            // Once this object becomes the DataContext, bindings such as
            // {Binding EquipmentName} know where to get their values.
            EquipmentEditor.DataContext = selectedEquipment;

            // CONTROL SWAPPING:
            // Hide the normal equipment list...
            EquipmentListPanel.Visibility = Visibility.Collapsed;

            // ...and show the editor.
            EquipmentEditor.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permanently removes the selected Equipment object from the collection.
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is not Equipment selectedEquipment)
            {
                MessageBox.Show("Please select equipment first.");
                return;
            }

            // Destructive actions should ask for confirmation.
            MessageBoxResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedEquipment.AssetNumber}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Removing the object from ObservableCollection automatically
                // notifies the DataGrid that the COLLECTION changed.
                // We do not need to reset ItemsSource.
                _equipmentItems.Remove(selectedEquipment);

                MessageBox.Show(
                    $"You have successfully deleted {selectedEquipment.AssetNumber}.");
            }
        }

        /// <summary>
        /// Handles the SaveRequested CUSTOM event raised by EquipmentEditControl.
        /// </summary>
        private void EquipmentEditor_SaveRequested(object? sender, EventArgs e)
        {
            // Because the edit fields use TwoWay binding, edits are applied to the
            // existing Equipment object. INotifyPropertyChanged lets other bound
            // controls notice property changes.
            //
            // For this demo, "Save" means return to the list interface.
            ShowEquipmentList();
        }

        /// <summary>
        /// Handles the BackRequested CUSTOM event raised by EquipmentEditControl.
        /// </summary>
        private void EquipmentEditor_BackRequested(object? sender, EventArgs e)
        {
            // IMPORTANT TEACHING NOTE:
            // With this simple direct TwoWay-binding design, Back only navigates
            // back to the list. It does NOT undo edits that have already reached
            // the original Equipment object.
            //
            // A true Cancel/Revert feature would require an edit copy/buffer or
            // another strategy for restoring the original values.
            ShowEquipmentList();
        }

        /// <summary>
        /// Changes the selected Equipment's state instead of deleting it.
        /// This demonstrates the difference between a destructive collection
        /// operation (Delete) and a state-changing operation (Retire).
        /// </summary>
        private void RetireButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is not Equipment selectedEquipment)
            {
                MessageBox.Show("Please select equipment first.");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                $"Are you sure you want to retire {selectedEquipment.EquipmentName}?",
                "Confirm Retirement",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Notice that we DO NOT remove the object from the collection.
                // We keep the Equipment record and change only its state.
                //
                // Equipment.Status raises PropertyChanged, so the DataGrid can
                // update the Status and derived AvailabilityMessage columns.
                selectedEquipment.Status = EquipmentStatus.Retired;
            }
        }

        /// <summary>
        /// Small helper method used by both Save and Back.
        /// Keeping the visibility logic in one place avoids repeating it.
        /// </summary>
        private void ShowEquipmentList()
        {
            // Hide the editing interface.
            EquipmentEditor.Visibility = Visibility.Collapsed;

            // Show the normal list interface again.
            EquipmentListPanel.Visibility = Visibility.Visible;
        }
    }
}
