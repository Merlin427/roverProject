using System;

namespace RoverNavV1
{
    public class RoverProgram
    {
        public static void Main(string[] args)
        {
            string topRightX = "5";
            string topRightY = "5";
            int gridMaxX = Int32.Parse(topRightX);
            int gridMaxY = Int32.Parse(topRightY);

            string rover1Start = "12N";
            string rover1Instructions = "LMLMLMLMM";
            string rover2Start = "33E";
            string rover2Instructions = "MMRMMRMRRM";
            var rover1 = new Rover(1, rover1Start, rover1Instructions, gridMaxX, gridMaxY);
            var rover2 = new Rover(2, rover2Start, rover2Instructions, gridMaxX, gridMaxY);
            rover1.RoverRun();
            rover2.RoverRun();
        }
    }
}