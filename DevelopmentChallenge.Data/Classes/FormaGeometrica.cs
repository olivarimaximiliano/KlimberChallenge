/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Classes.Formas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        public static string Imprimir(List<IForma> formas, Idioma idioma)
        {
            var sb = new StringBuilder();
            Traductor traductor = new Traductor(idioma);

            if (!formas.Any())
            {
                sb.Append($"<h1>{traductor.Traducir("Lista vacía de formas!")}</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{traductor.Traducir("Reporte de Formas")}</h1>");

                Dictionary<Type, Resultado> FormaResultado = new Dictionary<Type, Resultado>();

                formas.ForEach(f =>
                {
                    if (FormaResultado.ContainsKey(f.GetType()))
                    {
                        FormaResultado[f.GetType()].Cantidad++;
                        FormaResultado[f.GetType()].Area += f.CalcularArea();
                        FormaResultado[f.GetType()].Perimetro += f.CalcularPerimetro();
                    }
                    else
                    {
                        FormaResultado.Add(f.GetType(), new Resultado(1, f.CalcularArea(), f.CalcularPerimetro()));
                    }
                });

                var cantidadTotal = 0m;
                var areaTotal = 0m;
                var perimetroTotal = 0m;

                foreach (var tipo in FormaResultado.Keys)
                {
                    cantidadTotal += FormaResultado[tipo].Cantidad;
                    areaTotal += FormaResultado[tipo].Area;
                    perimetroTotal += FormaResultado[tipo].Perimetro;
                    sb.Append(ObtenerLinea(FormaResultado[tipo], tipo, traductor));
                }

                // FOOTER
                sb.Append(traductor.Traducir("TOTAL") + ":<br/>");
                sb.Append(cantidadTotal + " " + traductor.Traducir("formas") + " ");
                sb.Append(traductor.Traducir("Perimetro") + " " + perimetroTotal.ToString("#.##") + " ");
                sb.Append(traductor.Traducir("Area") + " " + areaTotal.ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(Resultado resultado, Type tipo, Traductor traductor)
        {
            if (resultado.Cantidad > 0)
            {
                return $"{resultado.Cantidad} {traductor.Traducir(TraducirForma(tipo, resultado.Cantidad))} | {traductor.Traducir("Area")} {resultado.Area:#.##} | {traductor.Traducir("Perimetro")} {resultado.Perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(Type tipo, int cantidad)
        {
            var nombre = cantidad == 1 ? tipo.Name : tipo.Name + "s";

            return nombre;
        }
    }
}