using MarsRoverConsoleApp.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRoverConsoleApp.Command
{
    public class PlateauCommand : ICommand
    {
        private readonly IPlateau _plateau;
        public PlateauCommand(IServiceProvider _serviceProvider)
        {
            _plateau = _serviceProvider.GetService<IPlateau>();
        }
        public CommandTypes CommandType { get; set; } = CommandTypes.PlateauCommand;

        public void ExecuteCommand(string command)
        {
            var areaSize = ParsePlateauCommand(command);
            _plateau.SetPosition(areaSize);
        }

        private Position ParsePlateauCommand(string command) {

            var splitCommand = command.Split(' ');
            return new Position
            {
                XCoordinate = int.Parse(splitCommand[0]) + 1,
                YCoordinate = int.Parse(splitCommand[1]) + 1
            };
        }
    }
}
