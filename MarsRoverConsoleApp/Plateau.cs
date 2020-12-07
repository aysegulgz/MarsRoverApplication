namespace MarsRoverConsoleApp
{
    public class Plateau : IPlateau
    {
        public Position PlateauSize { get; set; }

        public void SetPosition(Position position)
        {
            PlateauSize = position;
        }
    }
}
