using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ParcialUnoP_IV.Models;
using System.Linq;
using ParcialUnoP_IV.Data;
using Microsoft.AspNetCore.Authorization;

namespace ParcialUnoP_IV.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ParcialUnoP_IVContext _context;

        // Elimina uno de los constructores para resolver el error
        public HomeController( ParcialUnoP_IVContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList(); // Obtener la lista de clientes desde tu base de datos
            int totalDeudas = clientes.Sum(c => c.debt).Value;

            var ventas = _context.Ventas.ToList();
            int totalVentas = ventas.Sum(v => v.total).Value;

            ViewBag.TotalDeudas = totalDeudas;
            ViewBag.TotalVentas = totalVentas;
            return View(clientes); // Pasar la lista de clientes a la vista
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
