using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Circulo : IForma
    {
        public Circulo(decimal lado)
        {
            _lado = lado;
        }

        private readonly decimal _lado;

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }
    }
}