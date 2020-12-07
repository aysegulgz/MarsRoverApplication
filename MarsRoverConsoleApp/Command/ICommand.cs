using MarsRoverConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverConsoleApp.Command
{
    public interface ICommand
    {
        CommandTypes CommandType { get; set; }

        void ExecuteCommand(string command);
    }
}
