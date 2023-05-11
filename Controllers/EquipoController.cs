using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Equipos.Models;

namespace Equipos.Controllers
{
    [ApiController]
    [Route("api/equipos")]
    public class EquipoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Equipo>> GetEquipos()
        {
            using(FutbolContext context = new FutbolContext())
            {
                return Ok(context.Equipos.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Equipo> GetEquipo(int id)
        {
            using(FutbolContext context = new FutbolContext())
            {
                var equipo = context.Equipos.FirstOrDefault(e => e.Id == id);

                if (equipo == null)
                    return NotFound();

                return Ok(equipo);
            }
        }

        [HttpPost]
        public ActionResult<Equipo> PostEquipo(Equipo equipo)
        {
            using(FutbolContext ctx = new FutbolContext())
            {

                ctx.Equipos.Add(equipo);
                ctx.SaveChanges();

                return Ok(equipo);
            }
        }

        [HttpPut]
        public ActionResult<Equipo> PutEquipo(Equipo equipo)
        {
            using (FutbolContext ctx = new FutbolContext())
            {

                Equipo aux = ctx.Equipos.FirstOrDefault(c => c.Id == equipo.Id);

                if (aux == null)
                {
                    return NotFound();
                }
                else
                {
                    aux.Nombre = equipo.Nombre;
                    aux.Ciudad = equipo.Ciudad;
                    ctx.Equipos.Update(aux);
                    ctx.SaveChanges();

                    return Ok(equipo);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Equipo> DeleteEquipo(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                var equipo = context.Equipos.FirstOrDefault(e => e.Id == id);

                if (equipo == null)
                    return NotFound();
                else
                {
                    context.Equipos.Remove(equipo);
                    context.SaveChanges();
                    return Ok(equipo);
                }

                
            }
        }
    }
}
