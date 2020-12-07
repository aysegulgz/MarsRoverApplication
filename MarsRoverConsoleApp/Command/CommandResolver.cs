using MarsRoverConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MarsRoverConsoleApp.Command
{
    public class CommandResolver : ICommandResolver
    {
        private IDictionary<string, CommandTypes> commandTypeDictionary;

        private readonly IServiceProvider _serviceProvider;

        public CommandResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeCommandTypeDictionary();
        }

        public void ParseCommand(string commandString)
        {
            var commands = commandString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var command in commands)
            {
                var commandType = commandTypeDictionary.First(regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(command));

                var commandExecuter = GetCommandExecuterFromAssembly();
                var executer = commandExecuter.SingleOrDefault(x => x.CommandType == commandType.Value);
                executer.ExecuteCommand(command);
            }
        }

        private void InitializeCommandTypeDictionary()
        {
            commandTypeDictionary = new Dictionary<string, CommandTypes>
            {
                { @"^\d+ \d+$", CommandTypes.PlateauCommand },
                { @"^\d+ \d+ [NSEW]$", CommandTypes.RoverPositionCommand },
                { @"^[LRM]+$", CommandTypes.RoverExploreCommand }
            };
        }

        private IEnumerable<ICommand> GetCommandExecuterFromAssembly()
        {
            var interfaceType = typeof(ICommand);
            return Assembly.GetExecutingAssembly()
              .DefinedTypes
              .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(x => Activator.CreateInstance(x, _serviceProvider) as ICommand);
        }
    }
}
