using MarsRoverConsoleApp.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace MarsRoverConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICommandResolver, CommandResolver>()
                .AddSingleton<ICommand, PlateauCommand>()
                .AddSingleton<ICommand, RoverPositionCommand>()
                .AddSingleton<ICommand, RoverExploreCommand>()
                .AddSingleton<IPlateau, Plateau>()
                .AddSingleton<IRoverServices, RoverServices>()
                .BuildServiceProvider();

            var commandString = buildCommandString();

            Console.WriteLine("Input:");
            Console.WriteLine(commandString);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Output:");
            Console.WriteLine(Environment.NewLine);

            var commandResolver = new CommandResolver(serviceProvider);
            commandResolver.ParseCommand(commandString);

            Console.ReadLine();
        }

        private static string buildCommandString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }
    }
}
