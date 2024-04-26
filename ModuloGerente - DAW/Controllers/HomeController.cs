using Microsoft.AspNetCore.Mvc;
using ModuloGerente___DAW.Models;
using System.Diagnostics;

namespace ModuloGerente___DAW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult RedireccionarAIndex()
        {
            // Función para redireccionar a las otras páginas
            return RedirectToAction("Index");


        }

        public IActionResult RedireccionarAMesas()
        {
            return RedirectToAction("mesas");
            

        }

        public IActionResult mesas()
        {
            return View();
        }

        public IActionResult RedireccionarAPedidosAbiertos()
        {
            return RedirectToAction("pedidosabiertos");

        }
        public IActionResult pedidosabiertos()
        {
            return View();
        }

        public IActionResult RedireccionarAPedidosProceso()
        {
            return RedirectToAction("pedidosenproceso");

        }
        public IActionResult pedidosenproceso()
        {
            return View();
        }

        public IActionResult RedireccionarAPedidosCerrados()
        {
            return RedirectToAction("pedidoscerrados");

        }
        public IActionResult pedidoscerrados()
        {
            return View();
        }

        public IActionResult RedireccionarADetallesA()
        {
            return RedirectToAction("detallescuentasabiertas");

        }
        public IActionResult detallescuentasabiertas()
        {
            return View();
        }

        public IActionResult RedireccionarAVentasPorFecha()
        {
            return RedirectToAction("ventasporfecha");
        }

        public IActionResult ventasporfecha()
        {
            return View();
        }
    }
}
