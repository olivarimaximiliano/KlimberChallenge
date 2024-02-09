namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Rectangulo : IForma
    {
        public Rectangulo(decimal lado1, decimal lado2)
        {
            _lado1 = lado1;
            _lado2 = lado2;
        }

        private readonly decimal _lado1;
        private readonly decimal _lado2;

        public decimal CalcularArea()
        {
            return _lado1 * _lado2;
        }

        public decimal CalcularPerimetro()
        {
            return 2 * _lado1 + 2 * _lado2;
        }
    }
}