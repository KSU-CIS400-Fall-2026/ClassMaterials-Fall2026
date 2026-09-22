namespace UnitTestDemo
{
    // An enum provides a fixed set of valid delivery statuses.
    // Using an enum prevents us from relying on arbitrary strings
    // such as "delivered", "Delivered", or "DELIVERED".
    public enum DeliveryStatus
    {
        // Delivered is the first value and therefore has
        // an underlying numeric value of 0.
        Delivered,

        Pending,

        Processing,

        Cancelled
    }
}