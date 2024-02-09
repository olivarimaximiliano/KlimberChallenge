namespace DevelopmentChallenge.Data.Classes
{
    public class Resultado
    {
        public int Cantidad { get; set; }
        public decimal Area { get; set; }
        public decimal Perimetro { get; set; }

        public Resultado(int cantidad, decimal area, decimal perimetro)
        {
            Cantidad = cantidad;
            Area = area;
            Perimetro = perimetro;
        }
    }
}