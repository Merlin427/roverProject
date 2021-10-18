using System;

namespace RoverNavV1
{
    public class Rover
    {
        private readonly string _instructions;
        private readonly string _startPosition;
        private readonly int _roverNumber;
        private int _currentX;
        private int _currentY;
        private char _currentHeading;
        private readonly char[] _headingsArray = {'N', 'E', 'S', 'W'};
        private readonly int _gridMaxX;
        private readonly int _gridMaxY;
        private bool _roverLost;

        public Rover(int roverNumber, string startPosition, string instructions, int gridMaxX, int gridMaxY)
        {
            _instructions = instructions;
            _startPosition = startPosition;
            _roverNumber = roverNumber;
            _gridMaxX = gridMaxX;
            _gridMaxY = gridMaxY;

            GetCurrentPositionAndHeading();
        }

        private char UpdateHeading(int headingIndex)
        {
            var heading = _headingsArray[headingIndex];
            return heading;
        }

        private void GetCurrentPositionAndHeading()
        {
            var startPositionElements = _startPosition.ToCharArray();
            _currentX = int.Parse(startPositionElements[0].ToString());
            _currentY = int.Parse(startPositionElements[1].ToString());

            _currentHeading = startPositionElements[2];
        }

        public string RoverRun()
        {
            int currentHeadingIndex = Array.FindIndex<char>(_headingsArray, x => x == _currentHeading);
            char[] parsedInstructions = _instructions.ToCharArray();


            foreach (var instruction in parsedInstructions)
            {
                // Move the rover in the facing direction.
                if (instruction == 'M')
                {
                    MoveForward();
                }

                else if (instruction == 'L')
                {
                    currentHeadingIndex = TurnLeft(currentHeadingIndex);
                }

                else
                {
                    currentHeadingIndex = TurnRight(currentHeadingIndex);
                }

                if (_currentY > _gridMaxY || _currentX > _gridMaxX || _currentY < 0 || _currentX < 0)
                {
                    Console.WriteLine(
                        $"Rover {_roverNumber} went off the grid, your poor instructions cost NASA 1 Billion Dollars!!");
                    _roverLost = true;
                    break;
                }
            }
            
            var returnPosition = $"{_currentX}{_currentY}{_currentHeading}";
            
            if (_roverLost)
                return
                    $"Rover {_roverNumber} went off the grid, your poor instructions has cost NASA 1 Billion Dollars!!";
            Console.WriteLine($"Rover {_roverNumber} ended at {_currentX} {_currentY} {_currentHeading}");
            return (returnPosition);
        }

        private int TurnRight(int currentHeadingIndex)
        {
            if (currentHeadingIndex == 3)
            {
                currentHeadingIndex = 0;
                _currentHeading = UpdateHeading(currentHeadingIndex);
            }
            else
            {
                currentHeadingIndex++;
                _currentHeading = UpdateHeading(currentHeadingIndex);
            }
            return currentHeadingIndex;
        }

        private int TurnLeft(int currentHeadingIndex)
        {
            if (currentHeadingIndex < 3)
            {
                currentHeadingIndex++;
                _currentHeading = UpdateHeading(currentHeadingIndex);
            }
            else
            {
                currentHeadingIndex = 0;
                _currentHeading = UpdateHeading(currentHeadingIndex);
            }
            return currentHeadingIndex;
        }
        private void MoveForward()
        {
            switch (_currentHeading)
            {
                case 'N':
                    _currentY++;
                    break;
                case 'E':
                    _currentX++;
                    break;
                case 'S':
                    _currentY--;
                    break;
                default:
                    _currentX--;
                    break;
            }
        }
    }
}