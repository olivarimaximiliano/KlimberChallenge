namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Trapecio : IForma
    {
        public Trapecio(decimal base1, decimal base2, decimal altura)
        {
            _base1 = base1;
            _base2 = base2;
            _altura = altura;
        }

        private readonly decimal _base1;
        private readonly decimal _base2;
        private readonly decimal _altura;

        public decimal CalcularArea()
        {
            return ((_base1 + _base2) / 2) * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return (_altura * 2) + _base1 + _base2;
        }
    }
}