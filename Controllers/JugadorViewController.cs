using Equipos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Equipos.Controllers
{
    public class JugadorViewController : Controller
    {
        private readonly ILogger<JugadorViewController> _logger;

        public JugadorViewController(ILogger<JugadorViewController> logger)
        {
            _logger = logger;
        }
        public IActionResult IndexJugadores()
        {
            return View("Views/JugadorView/IndexJugador.cshtml");
        }

        public IActionResult DeleteJugador(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                context.Jugadores.Remove(context.Jugadores.FirstOrDefault(e => e.Id == id));
                context.SaveChanges();
                return View("Views/JugadorView/IndexJugador.cshtml");
            }
        }

        public IActionResult EditarJugador(int id)
        {
            using (FutbolContext context = new FutbolContext())
            {
                ViewData["Jugador"] = context.Jugadores.FirstOrDefault(e => e.Id == id);
                ViewData["Equipos"] = context.Equipos.ToList();
                return View("Views/JugadorView/UpdateJugador.cshtml");
            }
        }

        public IActionResult UpdateJugador(int id, string nombre, string apellidos, int idEquipo)
        {
            using (FutbolContext context = new FutbolContext())
            {
                Jugadore j = context.Jugadores.FirstOrDefault(e => e.Id == id);
                j.Nombre = nombre;
                j.IdEquipo = idEquipo;
                j.Apellidos = apellidos;
                context.Jugadores.Update(j);
                context.SaveChanges();
                return View("Views/JugadorView/IndexJugador.cshtml");
            }
        }

        public IActionResult CreateJugador()
        {
            using (FutbolContext context = new FutbolContext())
            {
                ViewData["Equipos"] = context.Equipos.ToList();
                return View("Views/JugadorView/CreateJugador.cshtml");
            }
        }

        public IActionResult NuevoJugador(string nombre, string apellidos, int idEquipo)
        {
            using (FutbolContext context = new FutbolContext())
            {
                Jugadore j = new Jugadore();
                {
                    j.Nombre = nombre;
                    j.IdEquipo = idEquipo;
                    j.Apellidos = apellidos;
                }
                context.Jugadores.Add(j);
                context.SaveChanges();
                return View("Views/JugadorView/IndexJugador.cshtml");
            }
        }
    }
}
