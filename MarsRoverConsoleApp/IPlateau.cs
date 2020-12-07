namespace MarsRoverConsoleApp
{
    public interface IPlateau
    {
        public Position PlateauSize { get;  }
        void SetPosition(Position position);
    }
}
