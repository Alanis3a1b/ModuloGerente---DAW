using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloGerente___DAW.Models;
using System.Diagnostics;

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

        public HomeController(dulcesaborDbContext dulcesaborDbContext)
        {
            _dulcesaborDbContext = dulcesaborDbContext;
        }


        public IActionResult Index()
        {

            //Listado para invocar los pedidos de restaurante
            //var listadoDeOrdenes = (from e in _dulcesaborDbContext.cuenta
            //                        join m in _dulcesaborDbContext.mesas on e.id_mesa equals m.id_mesa
            //                        join n in _dulcesaborDbContext.encabezado_fac on e.id_cuenta equals n.id_cliente
            //                        join dp in _dulcesaborDbContext.Detalles_pedidos on e.id_cuenta equals dp.id_cuenta
            //                        join df in _dulcesaborDbContext.detalle_fac on dp.id_detallecuenta equals df.id_detallepedido
            //                        join ef in _dulcesaborDbContext.encabezado_fac on df.id_factura equals ef.id_factura
            //                        select new
            //                        {
            //                            OrdenID = e.id_cuenta,
            //                            MesaID = e.id_mesa,
            //                            ClienteID = ef.id_cliente,
            //                            Plato = dp.tipo_plato,
            //                            precio = df.total_plato,
            //                            TOTAL = ef.total_cobrado                                        

            //                        }).ToList();
            //ViewData["listadoOrdenes"] = listadoDeOrdenes;

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
            // Funci�n para redireccionar a las otras p�ginas
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
            var pedidosProceso = (from dp in _dulcesaborDbContext.detalle_De_Pedidos
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

        public IActionResult RedireccionarAPedidosCerrados()
        {
            return RedirectToAction("pedidoscerrados");

        }
        public IActionResult pedidoscerrados()
        {
            var pedidosCerrados = (from dp in _dulcesaborDbContext.detalle_De_Pedidos
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
    }
}
