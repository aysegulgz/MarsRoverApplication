using MarsRoverConsoleApp;
using MarsRoverConsoleApp.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTests
{
    public class TestFixture
    {
        public TestFixture()
        {
            ServiceProvider = new ServiceCollection()
                .AddSingleton<ICommandResolver, CommandResolver>()
                .AddSingleton<ICommand, PlateauCommand>()
                .AddSingleton<ICommand, RoverPositionCommand>()
                .AddSingleton<ICommand, RoverExploreCommand>()
                .AddSingleton<IPlateau, Plateau>()
                .AddSingleton<IRoverServices, RoverServices>()
                .BuildServiceProvider();
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
