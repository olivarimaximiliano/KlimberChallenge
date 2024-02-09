namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : IForma
    {
        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        private readonly decimal _lado;

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}