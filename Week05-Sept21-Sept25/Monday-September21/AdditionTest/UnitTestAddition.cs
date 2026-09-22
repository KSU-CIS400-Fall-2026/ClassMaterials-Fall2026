using UnitTestDemo;

namespace AdditionTest
{
    public class UnitTestAddition
    {
        // [Fact] represents one specific test case with fixed test data.
        // This test checks that 15 + 85 produces the expected result of 100.
        [Fact]
        public void AddTwoIntegerTest()
        {
            // Arrange
            // Create the object that contains the method we want to test.
            MathOperations operation = new MathOperations();

            // Act
            // Call the method being tested and capture its actual result.
            int actual = operation.AddTwoIntegers(15, 85);

            // Assert
            // Compare the expected result with the result returned by the method.
            // Assert.Equal uses the order: expected value, actual value.
            Assert.Equal(100, actual);
        }

        // Another Fact test using a different pair of positive integers.
        [Fact]
        public void AddTwoIntegerTest2()
        {
            // Arrange
            MathOperations operation = new MathOperations();

            // Act
            int actual = operation.AddTwoIntegers(500, 450);

            // Assert
            Assert.Equal(950, actual);
        }

        // This Fact verifies that the method also works
        // correctly when both input values are negative.
        [Fact]
        public void AddTwoIntegerTest3()
        {
            // Arrange
            MathOperations operation = new MathOperations();

            // Act
            int actual = operation.AddTwoIntegers(-15, -20);

            // Assert
            Assert.Equal(-35, actual);
        }

        // [Theory] allows the same test method to run multiple times
        // using different sets of input data.
        //
        // Each InlineData row represents a separate test case.
        // The values correspond to:
        // firstNumber, secondNumber, expectedResult.
        [Theory]
        [InlineData(45, 85, 130)]
        [InlineData(-1, 91, 90)]
        [InlineData(0, 0, 0)]
        [InlineData(85, 100, 185)]
        [InlineData(2500, 1500, 4000)]
        [InlineData(1, 1, 2)]
        public void AddTwoIntegersMultipleTests(
            int firstNumber,
            int secondNumber,
            int expectedResult)
        {
            // Arrange
            // A new MathOperations object is created for each test case.
            MathOperations operation = new MathOperations();

            // Act
            // The values supplied by InlineData are passed to the method.
            int actual = operation.AddTwoIntegers(firstNumber, secondNumber);

            // Assert
            // Verify that the calculated result matches the expected
            // result supplied by the current InlineData test case.
            Assert.Equal(expectedResult, actual);
        }
    }
}