using CampusEquipment.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusEquipment.Models
{
    public class Equipment
    {
        public string AssetNumber { get; set; } = "";
        public string EquipmentName { get; set; } = "";
        //public string Category { get; set; } = "";
        public decimal DailyRentalRate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Condition { get; set; } = "";
        public bool IsAvailable { get; set; }

        public EquipmentCategory Category { get; set; } = EquipmentCategory.Camera;

    }
}
