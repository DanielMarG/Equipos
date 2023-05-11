using Equipos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Equipos.Controllers
{
    public class EquipoViewController : Controller
    {
        private readonly ILogger<EquipoViewController> _logger;

        public EquipoViewController(ILogger<EquipoViewController> logger)
        {
            _logger = logger;
        }

        public IActionResult IndexEquipo()
        {
            return View("Views/EquipoView/IndexEquipo.cshtml");
        }

        public IActionResult CreateEquipo() {
            return View("Views/EquipoView/CreateEquipo.cshtml");
        }

        public IActionResult NuevoEquipo(string Nombre, string Ciudad) {
            Equipo e = new Equipo()
            {
                Nombre = Nombre,
                Ciudad = Ciudad
            };
            using (FutbolContext context = new FutbolContext())
            {
                context.Equipos.Add(e);
                context.SaveChanges();
                return View("Views/EquipoView/IndexEquipo.cshtml");
            }

        }

        public IActionResult DeleteEquipo(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                context.Equipos.Remove(context.Equipos.FirstOrDefault(e => e.Id == id));
                context.SaveChanges();
                return View("Views/EquipoView/IndexEquipo.cshtml");
            }
        }

        public IActionResult UpdateEquipo(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                ViewData["Equipo"] = context.Equipos.FirstOrDefault(e => e.Id == id);
                return View("Views/EquipoView/UpdateEquipo.cshtml");
            }
        }

        public IActionResult UpdateFinalEquipo(int id, string nombre, string ciudad)
        {
            using(FutbolContext context = new FutbolContext())
            {
                Equipo e = context.Equipos.FirstOrDefault(e => e.Id == id);

                e.Nombre = nombre;
                e.Ciudad = ciudad;

                context.Equipos.Update(e);
                context.SaveChanges(true);
                return View("Views/EquipoView/IndexEquipo.cshtml");
            }
        }

        public IActionResult ExpandirEquipo(int id)
        {
            using(FutbolContext  ctx = new FutbolContext())
            {
                List<Jugadore> lista = ctx.Jugadores.Where(k => k.IdEquipo == id).ToList();
                ViewData["Jugadores"] = lista;
                ViewData["Equipo"] = (ctx.Equipos.FirstOrDefault(k => k.Id == id)).Nombre;
                return View("Views/JugadorView/ListadoJugadoresEquipo.cshtml");
            }
        }
    }
}
