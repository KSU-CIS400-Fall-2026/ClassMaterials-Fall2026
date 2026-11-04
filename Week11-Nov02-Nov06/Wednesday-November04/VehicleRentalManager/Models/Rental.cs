namespace VehicleRentalManager.Models
{
    /// <summary>
    /// Represents a vehicle rental transaction.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Unique rental number.
        /// Example: RENT-001
        /// </summary>
        public string RentalNumber { get; set; } = string.Empty;

        /// <summary>
        /// Name of the customer renting the vehicle.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// The vehicle associated with this rental.
        /// </summary>
        public Vehicle Vehicle { get; set; } = new Vehicle();

        /// <summary>
        /// Number of days for which the vehicle is rented.
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// Amount that the customer has already paid.
        /// </summary>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// Total cost of the rental.
        ///
        /// Notice that this value is DERIVED.
        /// We do not ask the user to manually enter it.
        /// </summary>
        
        public decimal TotalCharge
        {
            get
            {
                return Vehicle.DailyRate * NumberOfDays;
            }
        }
    }
}