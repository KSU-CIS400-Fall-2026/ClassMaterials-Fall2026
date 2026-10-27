using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionChangedWPF
{
    /// <summary>
    /// Represents one piece of equipment in our
    /// Campus Equipment Center.
    /// </summary>
    public class Equipment
    {
        // The unique asset number assigned to the equipment.
        public string AssetNumber { get; set; } = string.Empty;


        // The human-readable name of the equipment.
        public string EquipmentName { get; set; } = string.Empty;


        // The equipment category.
        public string Category { get; set; } = string.Empty;


        // The daily rental price.
        public decimal DailyRentalRate { get; set; }
    }
}