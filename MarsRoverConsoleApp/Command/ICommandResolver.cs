namespace MarsRoverConsoleApp.Command
{
    public interface ICommandResolver
    {
        void ParseCommand(string commandString);
    }
}
