using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Evento : EventArgs
    {
        public string Mensaje { get; set; }
    }
    public class LogicaPrincipal
    {
        static List<Persona> Personas = new List<Persona>();
        public EventHandler<Evento> Eventardo;

        public Persona cargarPersona(Persona persona)
        {
            Personas.Add(persona);
            if (Eventardo != null)
                Eventardo(this,new Evento() { Mensaje= "Se cargo la persona panaaaaaa"});
            return persona;
        }

        public List<Persona> buscarPersona(string id)
        {
            return Personas.Where(x=>x.Id==id).ToList();
        }
    }

    public class Persona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int PlataDisponible { get; set; }
        private int PlataTotal { get; set; }
        private bool EsMillonario { get { return PlataTotal > 10000; } set { } }
    }
}
