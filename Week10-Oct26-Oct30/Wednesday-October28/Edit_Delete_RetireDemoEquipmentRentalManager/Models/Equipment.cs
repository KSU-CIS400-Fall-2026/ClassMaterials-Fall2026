using System;
using System.ComponentModel;

namespace EquipmentRentalManager.Models
{
    /// <summary>
    /// Represents one piece of rental equipment.
    ///
    /// This class implements INotifyPropertyChanged because some of its
    /// properties can be edited while the object is already displayed in WPF.
    /// When a property changes, the object can notify the UI so the UI can
    /// refresh without us manually resetting the DataGrid's ItemsSource.
    /// </summary>
    public class Equipment : INotifyPropertyChanged
    {
        // AssetNumber identifies the equipment.
        // In our edit screen it is displayed as read-only, so this simple
        // auto-property is sufficient for the current demo.
        public string AssetNumber { get; set; } = "";

        // A backing field stores the actual value for EquipmentName.
        private string _equipmentName = "";

        public string EquipmentName
        {
            get => _equipmentName;

            set
            {
                // If the new value is the same as the old value,
                // there is no real change to report.
                if (_equipmentName == value)
                    return;

                _equipmentName = value;

                // Tell WPF that EquipmentName changed.
                OnPropertyChanged(nameof(EquipmentName));
            }
        }

        // Category is not edited in this particular demo's edit screen.
        public EquipmentCategory Category { get; set; }

        private decimal _dailyRentalRate;

        public decimal DailyRentalRate
        {
            get => _dailyRentalRate;

            set
            {
                // A simple domain rule: a rental rate cannot be negative.
                if (value < 0)
                    throw new ArgumentException("Daily rental rate cannot be negative.");

                if (_dailyRentalRate == value)
                    return;

                _dailyRentalRate = value;

                // Notify WPF so controls displaying the rate can refresh.
                OnPropertyChanged(nameof(DailyRentalRate));
            }
        }

        private EquipmentCondition _condition;

        public EquipmentCondition Condition
        {
            get => _condition;

            set
            {
                if (_condition == value)
                    return;

                _condition = value;

                // The edit ComboBox uses TwoWay binding to this property.
                // When the user chooses a new condition, WPF can update this
                // property, and this notification tells other bound controls
                // that Condition has changed.
                OnPropertyChanged(nameof(Condition));
            }
        }

        private EquipmentStatus _status;

        public EquipmentStatus Status
        {
            get => _status;

            set
            {
                if (_status == value)
                    return;

                _status = value;

                // Status itself changed.
                OnPropertyChanged(nameof(Status));

                // AvailabilityMessage is a DERIVED property.
                // It is calculated from Status. Therefore, when Status changes,
                // AvailabilityMessage may also produce a different result.
                // We notify WPF about BOTH properties.
                OnPropertyChanged(nameof(AvailabilityMessage));
            }
        }

        /// <summary>
        /// A derived/read-only property. We do not store a separate message.
        /// Instead, the message is calculated from the current Status.
        /// </summary>
        public string AvailabilityMessage
        {
            get
            {
                if (Status == EquipmentStatus.Retired)
                    return "No longer available";

                if (Status == EquipmentStatus.Maintenance)
                    return "Currently under maintenance";

                if (Status == EquipmentStatus.Rented)
                    return "Currently rented";

                return "Available for rental";
            }
        }

        // INotifyPropertyChanged requires this event.
        // WPF listens for this event when it is bound to properties on this object.
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises PropertyChanged for the property whose name is supplied.
        ///
        /// protected: this class and derived classes can call it.
        /// virtual: a derived class could override the behavior if necessary.
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // ?. means "invoke the event only if something is subscribed to it."
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
