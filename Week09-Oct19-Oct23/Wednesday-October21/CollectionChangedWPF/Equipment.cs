using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionChangedWPF
{
    /// <summary>
    /// Represents a piece of equipment available
    /// at the Campus Equipment Center.
    /// </summary>
    public class Equipment
    {
        // Unique identifier for the equipment.
        public string AssetNumber { get; set; } = string.Empty;

        // Name of the equipment.
        public string EquipmentName { get; set; } = string.Empty;

        // Category such as Laptop, Camera, or Projector.
        public string Category { get; set; } = string.Empty;

        // Amount charged per day to rent the equipment.
        public decimal DailyRentalRate { get; set; }
    }
}