using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModuloGerente___DAW.Models;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace ModuloGerente___DAW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly dulcesaborDbContext _dulcesaborDbContext;
        public HomeController(dulcesaborDbContext dulcesaborDbContext/*, pedidosContext pedidosContext*/)
        {
            _dulcesaborDbContext = dulcesaborDbContext;
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
            //Listado de las mesas
            var listaDeMesas = (from m in _dulcesaborDbContext.mesas
                                 join e in _dulcesaborDbContext.estados on m.id_estado equals e.id_estado
                                select new
                                {
                                    nombre_mesa = m.nombre_mesa,
                                    estado = e.nombre
                                    
                                }).ToList();

            ViewData["listadoDeMesas"] = listaDeMesas;

            return View();
        }

        public IActionResult RedireccionarAPedidosAbiertos()
        {
            return RedirectToAction("pedidosabiertos");

        }
        public IActionResult pedidosabiertos()
        {
            //Listado para invocar los pedidos de restaurante
            var pedidosAbiertos = (from dp in _dulcesaborDbContext.detalle_de_pedido
                                   join p in _dulcesaborDbContext.pedido on dp.id_pedido equals p.id_pedido
                                   join c in _dulcesaborDbContext.comida on dp.id_comida equals c.id_comida
                                   where p.estado == "Abierto"
                                   group new { dp, p, c } by p.id_pedido into g
                                   select new
                                   {
                                       estado = _dulcesaborDbContext.pedido.FirstOrDefault(p => p.id_pedido == g.Key).estado,
                                       id_pedido = g.Key,
                                       detalles = g.Select(x => new
                                       {
                                           nombre_comida = x.c.nombre,
                                           costo_comida = x.c.precio,
                                       }),
                                       total = g.Sum(x => x.c.precio)
                                   }).ToList();

            ViewData["pedidosAbiertos"] = pedidosAbiertos;



            ViewData["pedidosAbiertos"] = pedidosAbiertos;
            return View();
        }

        public IActionResult RedireccionarAPedidosProceso()
        {
            return RedirectToAction("pedidosenproceso");

        }
        public IActionResult pedidosenproceso()
        {
            var pedidosProceso = (from dp in _dulcesaborDbContext.detalle_de_pedido
                                  join p in _dulcesaborDbContext.pedido on dp.id_pedido equals p.id_pedido
                                  join c in _dulcesaborDbContext.comida on dp.id_comida equals c.id_comida
                                  where p.estado == "En Proceso"
                                  group new { dp, p, c } by p.id_pedido into g
                                  select new
                                  {
                                      id_pedido = g.Key,
                                      detalles = g.Select(x => new
                                      {
                                          nombre_comida = x.c.nombre,
                                          costo_comida = x.c.precio
                                      }),
                                      total = g.Sum(x => x.c.precio)
                                  }).ToList();

            ViewData["pedidosProceso"] = pedidosProceso;
            return View();
        }

        /* 
         public IActionResult pedidosenproceso()
        {
            var pedidosProceso = (from dp in _dulcesaborDbContext.detalles_pedidos
                                  join p in _dulcesaborDbContext.pedidos on dp.id_pedido equals p.id_pedido
                                  join c in _dulcesaborDbContext.items_menu on dp.id_comida equals c.id_item_menu
                                  where p.estado == "En Proceso"
                                  group new { dp, p, c } by p.id_pedido into g
                                  select new
                                  {
                                      id_pedido = g.Key,
                                      detalles = g.Select(x => new
                                      {
                                          nombre_comida = x.c.nombre,
                                          costo_comida = x.c.precio
                                      }),
                                      total = g.Sum(x => x.c.precio)
                                  }).ToList();

            ViewData["pedidosProceso"] = pedidosProceso;
            return View();
        } 
        */

        /* 
         public IActionResult pedidosenproceso()
        {
            var pedidosProceso = (from dp in _dulcesaborDbContext.detalles_pedidos
                                  join p in _dulcesaborDbContext.pedidos on dp.id_pedido equals p.id_pedido
                                  join c in _dulcesaborDbContext.items_menu on dp.id_comida equals c.id_item_menu
                                  where p.estado == "Entregado"
                                  group new { dp, p, c } by p.id_pedido into g
                                  select new
                                  {
                                      id_pedido = g.Key,
                                      detalles = g.Select(x => new
                                      {
                                          nombre_comida = x.c.nombre,
                                          costo_comida = x.c.precio
                                      }),
                                      total = g.Sum(x => x.c.precio)
                                  }).ToList();

            ViewData["pedidosProceso"] = pedidosProceso;
            return View();
        } 
        */

        public IActionResult RedireccionarAPedidosCerrados()
        {
            return RedirectToAction("pedidoscerrados");

        }
        public IActionResult pedidoscerrados()
        {
            var pedidosCerrados = (from dp in _dulcesaborDbContext.detalle_de_pedido
                                   join p in _dulcesaborDbContext.pedido on dp.id_pedido equals p.id_pedido
                                   join c in _dulcesaborDbContext.comida on dp.id_comida equals c.id_comida
                                   where p.estado == "Entregado"
                                   group new { dp, p, c } by p.id_pedido into g
                                   select new
                                   {
                                       id_pedido = g.Key,
                                       detalles = g.Select(x => new
                                       {
                                           nombre_comida = x.c.nombre,
                                           costo_comida = x.c.precio
                                       }),
                                       total = g.Sum(x => x.c.precio)
                                   }).ToList();

            ViewData["pedidosCerrados"] = pedidosCerrados;
            return View();
        }

        public IActionResult RedireccionarADetallesA()
        {
            return RedirectToAction("detallescuentasabiertas");

        }
        public IActionResult detallescuentasabiertas()
        {
            //Listado para invocar los pedidos
            var pedidosDetalles = (from dp in _dulcesaborDbContext.detalle_de_pedido
                                   join p in _dulcesaborDbContext.pedido on dp.id_pedido equals p.id_pedido
                                   join c in _dulcesaborDbContext.comida on dp.id_comida equals c.id_comida
                                   where p.estado == "Abierto"
                                   group new { dp, p, c } by p.id_pedido into g
                                   select new
                                   {
                                       estado = _dulcesaborDbContext.pedido.FirstOrDefault(p => p.id_pedido == g.Key).estado,
                                       id_pedido = g.Key,
                                       detalles = g.Select(x => new
                                       {
                                           nombre_comida = x.c.nombre,
                                           costo_comida = x.c.precio,
                                       }),
                                       total = g.Sum(x => x.c.precio)
                                   }).ToList();

            ViewData["pedidosDetalles"] = pedidosDetalles;


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

        public IActionResult RedireccionarAVentasPorMes()
        {
            return RedirectToAction("ventaspormes");
        }

        public IActionResult ventaspormes()
        {
            return View();
        }

        public IActionResult RedireccionarACuentasCerradas()
        {
            return RedirectToAction("cuentacerrada");

        }

        public IActionResult cuentacerrada()
        {
            return View();
        }

        public IActionResult RedireccionarAVentasEnLinea()
        {
            return RedirectToAction("ventasenlinea");

        }

        public IActionResult ventasenlinea()
        {
            return View();
        }
    }
}
