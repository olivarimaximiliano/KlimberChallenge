using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DevelopmentChallenge.Data.Classes
{
    public class Traductor
    {
        readonly Dictionary<string, string> _traducciones;
        public Traductor(Idioma idioma)
        {
            var file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Idiomas\\{idioma}.json");
            if (File.Exists(file))
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    _traducciones = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }
            }
            else
                _traducciones= new Dictionary<string, string>();
        }

        public string Traducir(string valor)
        {
            if (_traducciones.ContainsKey(valor))
                return _traducciones[valor];

            return valor;
        }
    }

    public enum Idioma
    {
        Castellano = 1,
        Ingles = 2,
        Italiano = 3
    }
}
