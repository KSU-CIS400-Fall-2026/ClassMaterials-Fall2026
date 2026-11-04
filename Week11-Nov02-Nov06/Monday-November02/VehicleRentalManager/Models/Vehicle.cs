namespace VehicleRentalManager.Models
{
    /// <summary>
    /// Represents one vehicle that can be rented.
    ///
    /// This is a MODEL class.
    ///
    /// Its job is to represent application data.
    /// It does not know anything about TextBlocks,
    /// DataGrids, HTML reports, or WPF controls.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// A unique identifier displayed to the user.
        /// Example: VEH-001
        /// </summary>
        public string VehicleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The make and model of the vehicle.
        /// Example: Toyota Camry
        /// </summary>
        public string MakeModel { get; set; } = string.Empty;

        /// <summary>
        /// How much it costs to rent this vehicle for one day.
        /// </summary>
        public decimal DailyRate { get; set; }

        /// <summary>
        /// True means the vehicle is currently available.
        /// False means it is currently rented.
        /// </summary>
        public bool IsAvailable { get; set; } = true;
    }
}