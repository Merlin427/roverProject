using NUnit.Framework;
using RoverNavV1;

namespace RoverNav.Test
{
    public class Tests
    {

        [TestCase("12N", "LMLMLMLMM", 5, 5, ExpectedResult = "13N")]
        [TestCase("33E", "MMRMMRMRRM", 5, 5, ExpectedResult = "51E")]
        [TestCase("33E", "MMRMMRMRRM", 3, 5, ExpectedResult = "Rover 1 went off the grid, your poor instructions has cost NASA 1 Billion Dollars!!")]
        public string TestRover_ShouldReturnCorrectRoverPosition(string startPosition, string instructions, int gridMaxX, int gridMaxY)
        {
            // Arrange
            var rover = new Rover(1, startPosition, instructions, gridMaxX, gridMaxY);
            
            // ACT AND ASSERT
            var result = rover.RoverRun();

            return result;

        }
    }
}