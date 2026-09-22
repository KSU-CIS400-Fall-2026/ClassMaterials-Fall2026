namespace UnitTestDemo
{
    
        // This class contains the production code that we want to test.
        // Unit tests should normally test small, focused behaviors of a class.
        public class MathOperations
        {
            // Accepts two integers and returns their sum.
            // Our unit tests will verify that this method produces
            // the correct result for different combinations of integers.
            public int AddTwoIntegers(int x, int y)
            {
                return x + y;
            }
        }
    
}
