using MarsRoverConsoleApp.Enums;

namespace MarsRoverConsoleApp
{
    public class Rover 
    {
        public Rover()
        {
            this.RoverPosition = new Position();
        }
        public Position RoverPosition { get; set; }
        public Directions RoverDirection { get; set; }
    }
}
