using Microsoft.AspNetCore.Mvc;
using Equipos.Models;

namespace Equipos.Controllers
{
    [ApiController]
    [Route("api/jugadores")]
    public class JugadorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Equipo>> GetJugadores()
        {
            using (FutbolContext context = new FutbolContext())
            {
                return Ok(context.Jugadores.ToList());
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Jugadore> GetJugador(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                var jugador = context.Jugadores.FirstOrDefault(e => e.Id == id);

                if (jugador == null)
                    return NotFound();

                return Ok(jugador);
            }
        }

        [HttpGet("equipo/{id}")]
        public ActionResult<IEnumerable<Jugadore>> GetJugadoresEquipo(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                var jugadores = context.Jugadores.Where(e => e.IdEquipo == id).ToList();

                if (jugadores.Count() <1)
                    return NotFound();

                return Ok(jugadores);
            }
        }

        [HttpPost]
        public ActionResult<Jugadore> PostEquipo(Jugadore jugador)
        {
            using (FutbolContext ctx = new FutbolContext())
            {

                ctx.Jugadores.Add(jugador);
                ctx.SaveChanges();

                return Ok(jugador);
            }
        }

        [HttpPut]
        public ActionResult<Jugadore> PutEquipo(Jugadore jugador)
        {
            using (FutbolContext ctx = new FutbolContext())
            {
                Jugadore aux = ctx.Jugadores.FirstOrDefault(c => c.Id == jugador.Id);

                if (aux == null)
                {
                    return NotFound();
                }
                else
                {
                    aux.Nombre = jugador.Nombre;
                    aux.Apellidos = jugador.Apellidos;
                    aux.IdEquipo = jugador.IdEquipo;
                    ctx.Jugadores.Update(aux);
                    ctx.SaveChanges();

                    return Ok(jugador);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Jugadore> DeleteEquipo(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                var jugador = context.Jugadores.FirstOrDefault(e => e.Id == id);

                if (jugador == null)
                    return NotFound();
                else
                {
                    context.Jugadores.Remove(jugador);
                    context.SaveChanges();
                    return Ok(jugador);
                }
            }
        }
    }
}
