using FluentAssertions;
using MarsRoverConsoleApp.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoverTests
{
    public class CommandResolverTests :IClassFixture<TestFixture>
    {
        private ServiceProvider _serviceProvider;
        public CommandResolverTests(TestFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
        [Theory]
        [InlineData("6 6")]
        public void ParseCommandForPlateauCommandTypeShouldBeSuccessfull(string command)
        {
            //Arrange
            var commandResolver = new CommandResolver(_serviceProvider);
            
            //Act
            var exception = Record.Exception(() => commandResolver.ParseCommand(command));

            //Assert
            exception.Should().BeNull();
        }

        [Theory]
        [InlineData("1 2 E")]
        public void ParseCommandForRoverPositionCommandTypeShouldBeSuccessfull(string command)
        {
            //Arrange
            var commandResolver = new CommandResolver(_serviceProvider);

            //Act
            var exception = Record.Exception(() => commandResolver.ParseCommand(command));

            //Assert
            exception.Should().BeNull();
        }

        [Theory]
        [InlineData("5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM")]
        public void ParseCommandForRoverExploreCommandTypeShouldBeSuccessfull(string command)
        {
            //Arrange
            var commandResolver = new CommandResolver(_serviceProvider);

            //Act
            var exception = Record.Exception(() => commandResolver.ParseCommand(command));

            //Assert
            exception.Should().BeNull();
        }
    }
}
