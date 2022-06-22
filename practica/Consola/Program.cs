using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var URL = "https://localhost:44335/Persona/CargarPersona";

            WebRequest request = WebRequest.Create(URL);

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                var respuesta = JsonConvert.DeserializeObject<dynamic>(responseFromServer);

                Console.WriteLine($"Nombre:{respuesta.Nombre}. Zona horaria: {respuesta.Id}. Estados {respuesta.PlataDisponible}");
            }
        }
    }
}
