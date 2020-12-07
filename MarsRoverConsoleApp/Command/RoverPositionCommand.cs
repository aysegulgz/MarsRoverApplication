using MarsRoverConsoleApp.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRoverConsoleApp.Command
{
    public class RoverPositionCommand : ICommand
    {
        public CommandTypes CommandType { get; set; } = CommandTypes.RoverPositionCommand;

        private readonly IRoverServices _roverServices;
        public RoverPositionCommand(IServiceProvider _serviceProvider)
        {
            _roverServices = _serviceProvider.GetService<IRoverServices>();
        }
        public void ExecuteCommand(string command)
        {
            var rover = ParseCommand(command);
            _roverServices.SetRoversPositionAndDirection(rover);
        }

        private Rover ParseCommand(string command)
        {
            var splittedCommand = command.Split(' ');
            return new Rover()
            {
                RoverPosition = new Position()
                {
                    XCoordinate = int.Parse(splittedCommand[0]),
                    YCoordinate = int.Parse(splittedCommand[1])
                },
                RoverDirection = Enum.Parse<Directions>(splittedCommand[2])
            };
        }
    }
}
