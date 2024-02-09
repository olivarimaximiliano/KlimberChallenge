using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : IForma
    {
        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        private readonly decimal _lado;
        public decimal Lado { get => _lado; }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}