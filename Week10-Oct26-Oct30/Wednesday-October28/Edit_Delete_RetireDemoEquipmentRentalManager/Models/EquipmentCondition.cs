namespace EquipmentRentalManager.Models
{
    /// <summary>
    /// Defines the physical condition choices shown in the edit ComboBox.
    /// EquipmentEditControl reads these values with Enum.GetValues(...).
    /// </summary>
    public enum EquipmentCondition
    {
        New,
        Good,
        Fair,
        Poor
    }
}
