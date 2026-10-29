using EquipmentRentalManager.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EquipmentRentalManager.Controls.Editing
{
    /// <summary>
    /// Code-behind for the reusable Equipment editing UserControl.
    ///
    /// This child control is responsible for its own editing interface.
    /// When the user clicks Save or Back, it raises a CUSTOM C# event.
    /// The parent EquipmentControl decides what should happen next.
    ///
    /// This keeps the child control from needing to know details about
    /// EquipmentControl's layout or navigation.
    /// </summary>
    public partial class EquipmentEditControl : UserControl
    {
        // CUSTOM EVENTS -------------------------------------------------
        // These are declared at class level: inside the class but OUTSIDE
        // the constructor and outside the button-handler methods.
        //
        // Think of these as messages the child can send to its parent:
        // "The user requested Save."
        // "The user requested Back."
        public event EventHandler? SaveRequested;
        public event EventHandler? BackRequested;

        public EquipmentEditControl()
        {
            InitializeComponent();

            // Populate the Condition ComboBox with every value from the
            // EquipmentCondition enum: New, Good, Fair, and Poor.
            // This prevents students from hard-coding duplicate enum strings
            // into the XAML.
            ConditionComboBox.ItemsSource =
                Enum.GetValues(typeof(EquipmentCondition));
        }

        /// <summary>
        /// Handles WPF's built-in Button.Click event.
        /// Instead of directly hiding controls in the parent, this child raises
        /// its own SaveRequested event and lets EquipmentControl respond.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // ?. means: raise the event only if at least one listener subscribed.
            // 'this' is the object raising the event.
            // EventArgs.Empty means we do not need to send extra information.
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the custom BackRequested event.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
