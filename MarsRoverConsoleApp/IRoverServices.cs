using MarsRoverConsoleApp.Enums;
using System.Collections.Generic;

namespace MarsRoverConsoleApp
{
    public interface IRoverServices
    {
        public void SetRoversPositionAndDirection(Rover rover);
        public Rover Process(List<Moves> moves);
    }
}
