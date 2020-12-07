using MarsRoverConsoleApp.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverConsoleApp.Command
{
    public class RoverExploreCommand : ICommand
    {
        public CommandTypes CommandType { get; set; } = CommandTypes.RoverExploreCommand;

        private readonly IRoverServices _roverServices;
        public RoverExploreCommand(IServiceProvider _serviceProvider)
        {
            _roverServices = _serviceProvider.GetService<IRoverServices>();
        }
        public void ExecuteCommand(string command)
        {
            var commandList = ParseMovements(command);

            var rover = _roverServices.Process(commandList);

            Console.WriteLine($"{rover.RoverPosition.XCoordinate} {rover.RoverPosition.YCoordinate} {rover.RoverDirection}");
        }

        private List<Moves> ParseMovements(string command)
        {
            var movements = command.ToCharArray();
            return movements.Select(move => Enum.Parse<Moves>(move.ToString())).ToList();
        }
    }
}
