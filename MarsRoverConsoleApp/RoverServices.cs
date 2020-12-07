using MarsRoverConsoleApp.Enums;
using System;
using System.Collections.Generic;

namespace MarsRoverConsoleApp
{
    public class RoverServices : IRoverServices
    {
        public Rover Rover { get; private set; }

        private readonly IPlateau _plateau;

        public RoverServices(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public void SetRoversPositionAndDirection(Rover rover)
        {
            Rover = rover;
        }
        public Rover Process(List<Moves> moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case Moves.L:
                        TurnLeft();
                        break;
                    case Moves.R:
                        TurnRight();
                        break;
                    case Moves.M:
                        MoveForward();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid move: {0}", move));
                }
            }
            return Rover;
        }
        private void TurnLeft()
        {
            Rover.RoverDirection = (Rover.RoverDirection - 1) < Directions.N ? Directions.W : Rover.RoverDirection - 1;
        }
        private void TurnRight()
        {
            Rover.RoverDirection = (Rover.RoverDirection + 1) > Directions.W ? Directions.N : Rover.RoverDirection + 1;
        }
        private void MoveForward()
        {
            switch (Rover.RoverDirection)
            {
                case Directions.N:
                    if (Rover.RoverPosition.YCoordinate + 1 <= _plateau.PlateauSize.YCoordinate)
                        Rover.RoverPosition.YCoordinate++;
                    break;

                case Directions.E:
                    if (Rover.RoverPosition.XCoordinate + 1 <= _plateau.PlateauSize.XCoordinate)
                        Rover.RoverPosition.XCoordinate++;
                    break;

                case Directions.S:
                    if (Rover.RoverPosition.YCoordinate - 1 >= 0)
                        Rover.RoverPosition.YCoordinate--;
                    break;

                case Directions.W:
                    if (Rover.RoverPosition.XCoordinate - 1 >= 0)
                        Rover.RoverPosition.XCoordinate--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
