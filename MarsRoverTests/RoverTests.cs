using FluentAssertions;
using MarsRoverConsoleApp;
using MarsRoverConsoleApp.Enums;
using MarsRoverTests.Data;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        [Theory]
        [MemberData(nameof(RoverTestData.GetRoverTestDataForSuccessfullTry), MemberType = typeof(RoverTestData))]
        public void FindRoversCoodinatesAndDirectionsShouldBeSuccessfull(int x, int y, Directions direction, List<Moves> moves)
        {
            //Arrange
            var size = new Position();
            size.XCoordinate = 8;
            size.YCoordinate = 8;

            IPlateau plateau = new Plateau();
            plateau.SetPosition(size);

            var rover = new Rover();
            rover.RoverPosition.XCoordinate = x;
            rover.RoverPosition.YCoordinate = y;
            rover.RoverDirection = direction;

            IRoverServices roverService = new RoverServices(plateau);

            //Act
            roverService.SetRoversPositionAndDirection(rover);
            var result = roverService.Process(moves);

            result.RoverPosition.XCoordinate.Should().Be(4);
            result.RoverPosition.YCoordinate.Should().Be(4);
            result.RoverDirection.Should().Be(Directions.E);
        }

        [Theory]
        [MemberData(nameof(RoverTestData.GetRoverTestDataForInvalidMoveTry), MemberType = typeof(RoverTestData))]
        public void ReturnExceptionForInvalidMove(int x, int y, Directions direction, List<Moves> moves)
        {
            //Arrange
            var size = new Position();
            size.XCoordinate = 5;
            size.YCoordinate = 5;

            IPlateau plateau = new Plateau();
            plateau.SetPosition(size);

            var rover = new Rover();
            rover.RoverPosition.XCoordinate = x;
            rover.RoverPosition.YCoordinate = y;
            rover.RoverDirection = direction;

            IRoverServices roverService = new RoverServices(plateau);

            //Act
            roverService.SetRoversPositionAndDirection(rover);

            Exception ex = Assert.Throws<ArgumentException>(() => roverService.Process(moves));
            Assert.Equal("Invalid move: 4", ex.Message);

        }

        [Theory]
        [MemberData(nameof(RoverTestData.GetRoverTestDataForOutOfAreaTry), MemberType = typeof(RoverTestData))]
        public void RoversCoordinatesShouldtBeGreaterThanAreaCoodinates(int x, int y, Directions direction, List<Moves> moves)
        {
            //Arrange
            var size = new Position();
            size.XCoordinate = 2;
            size.YCoordinate = 2;

            IPlateau plateau = new Plateau();
            plateau.SetPosition(size);

            var rover = new Rover();
            rover.RoverPosition.XCoordinate = x;
            rover.RoverPosition.YCoordinate = y;
            rover.RoverDirection = direction;

            IRoverServices roverService = new RoverServices(plateau);

            //Act
            roverService.SetRoversPositionAndDirection(rover);
            var result = roverService.Process(moves);

            //Assert
            result.RoverPosition.XCoordinate.Should().BeLessOrEqualTo(2);
            result.RoverPosition.YCoordinate.Should().BeLessOrEqualTo(2);
        }
    }
}
