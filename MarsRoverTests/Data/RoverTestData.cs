using MarsRoverConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTests.Data
{
    public class RoverTestData
    {
        public static IEnumerable<object[]> GetRoverTestDataForSuccessfullTry()
        {
            return new[]
            {
                new object[] {  0, 4, Directions.N, new List<Moves>() { Moves.R, Moves.M, Moves.M, Moves.M, Moves.M } },
                new object[] {  6, 1, Directions.W, new List<Moves>() { Moves.R, Moves.M, Moves.M, Moves.M, Moves.L, Moves.M, Moves.M,Moves.R,Moves.R } },
                new object[] {  1, 1, Directions.N, new List<Moves>() { Moves.R, Moves.M, Moves.L, Moves.M, Moves.M, Moves.R, Moves.M, Moves.M} }
            };
        }

        public static IEnumerable<object[]> GetRoverTestDataForInvalidMoveTry()
        {
            return new[]
            {
                new object[] {  0, 2, Directions.N, new List<Moves>() { Moves.R, Moves.M, (Moves)4 ,Moves.M, Moves.M, Moves.M } },
            };
        }
        public static IEnumerable<object[]> GetRoverTestDataForOutOfAreaTry()
        {
            return new[]
            {
                new object[] {  0, 2, Directions.N, new List<Moves>() { Moves.R, Moves.M, Moves.M, Moves.M, Moves.M, Moves.M } },
            };
        }
    }
}
