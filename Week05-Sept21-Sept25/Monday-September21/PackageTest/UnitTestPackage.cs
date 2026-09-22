using UnitTestDemo;

namespace PackageTest
{
    public class UnitTestPackage
    {
        // This test verifies the expected default state of a new Package.
        // No values are changed after creating the object, so we are
        // specifically testing the defaults defined by the Package class.
        [Fact]
        public void PackageTesting()
        {
            // Arrange
            // Create a new Package without assigning any additional values.
            Package package = new Package();

            // Assert
            // A new package should start with an empty TrackingID.
            Assert.Equal("", package.TrackingID);

            // The default delivery status should be Delivered.
            Assert.Equal(DeliveryStatus.Delivered, package.Status);

            // Because Status is Delivered, the derived IsDelivered
            // property should evaluate to true.
            Assert.True(package.IsDelivered);
        }
    }
}