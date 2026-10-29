namespace EquipmentRentalManager.Models
{
    /// <summary>
    /// Represents the current operational state of an Equipment object.
    /// Retiring equipment changes this state; it does not delete the record.
    /// </summary>
    public enum EquipmentStatus
    {
        Available,
        Rented,
        Maintenance,
        Retired
    }
}
