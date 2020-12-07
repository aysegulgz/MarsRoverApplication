using MarsRoverConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverConsoleApp
{
    public interface IRover
    {
        public Position RoverPosition { get; set; }
        public Directions RoverDirection { get; set; }

    }
}
