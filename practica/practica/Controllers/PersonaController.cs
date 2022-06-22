using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace practica.Controllers
{
    [RoutePrefix("Persona")]
    public class PersonaController : ApiController
    {
        Logica.LogicaPrincipal logica = new Logica.LogicaPrincipal(); 
        [Route("CargarPersona")]
        public IHttpActionResult CargarPersona(Persona persona)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logica.Eventardo += EventHandlerService;
            return Created("",logica.cargarPersona(persona.PasarAPersonaLogica()).PasarAPersonaServicio());
        }

        [Route("BuscarPersona")]
        public IHttpActionResult Get(string id)
        {
            List<Persona> personasServicio = new List<Persona>();
            foreach (Logica.Persona personaLogica in logica.buscarPersona(id))
            {
                personasServicio.Add(personaLogica.PasarAPersonaServicio());
            }
            return Ok(personasServicio);
        }

        static void EventHandlerService(object sender, Logica.Evento e)
        {
            Console.WriteLine(e.Mensaje);
        }
    }

    public class Persona
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int PlataDisponible { get; set; }
    }

    public static class ClaseEstatica
    {
        public static Logica.Persona PasarAPersonaLogica(this Persona persona)
        {
            return new Logica.Persona()
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                PlataDisponible = persona.PlataDisponible
            };
        }

        public static Persona PasarAPersonaServicio(this Logica.Persona persona)
        {
            return new Persona()
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                PlataDisponible = persona.PlataDisponible
            };
        }
    }
}
