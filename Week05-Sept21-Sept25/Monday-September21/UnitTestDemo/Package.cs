namespace UnitTestDemo
{
    // Package gives us a different type of class to test.
    // Instead of only testing a method, we can test default
    // property values, enum values, and a derived property.
    public class Package
    {
        // Every new Package starts with an empty TrackingID.
        // This gives us a known default value that can be unit tested.
        public string TrackingID { get; set; } = string.Empty;

        // Every new Package is explicitly initialized as Delivered.
        // We can write a test to confirm that this default is correct.
        public DeliveryStatus Status { get; set; }
            = DeliveryStatus.Delivered;

        // IsDelivered is a derived property because its value depends
        // on another property rather than being stored separately.
        public bool IsDelivered
        {
            get
            {
                // A package is considered delivered only when its
                // current Status is DeliveryStatus.Delivered.
                if (Status == DeliveryStatus.Delivered)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}