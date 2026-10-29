namespace EquipmentRentalManager.Models
{
    /// <summary>
    /// Defines the allowed categories for Equipment.
    /// Using an enum gives us a controlled set of valid values instead of
    /// relying on arbitrary strings such as "laptop" or "Laptop".
    /// </summary>
    public enum EquipmentCategory
    {
        Laptop,
        Camera,
        Projector,
        Tablet,
        Microphone
    }
}
