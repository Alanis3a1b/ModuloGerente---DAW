using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace ModuloGerente___DAW.Models
{
    //Tablas de la parte de pedidos en línea
    public class pedidos
    {
        [Key]
        public int id_pedido { get; set; }
        public int id_usuario { get; set; }
        public string estado { get; set; }
        public int id_pago { get; set; }
        public decimal total { get; set; }
        public DateTime fecha_hora { get; set; }
        public int? com_prom { get; set; }
        public int? direccion { get; set; }


    }

    public class detalles_pedidos
    {
        [Key]
        public int id_detalles_pedidos { get; set; }
        public int id_pedido { get; set; }
        public int id_comida { get; set; }
        public string tipo_plato { get; set; }
        public string? comentario { get; set; }

    }

    public class comentarios
    {
        [Key]
        public int id_comentario { get; set; }
        public int id_detallepedido { get; set; }
        public int? comentario { get; set; }

    }

    public class direcciones
    {
        [Key]
        public int id_direc { get; set; }
        public string direccion { get; set; }

    }

    public class pagos
    {
        [Key]
        public int id_pagos { get; set; }
        public int forma_pago { get; set; }
        public decimal total { get; set; }
        public int id_usuario { get; set; }
    }

    public class usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string? direccion { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena { get; set; }
        public string? foto { get; set; }

    }

    //Tablas de la parte de pedidos en el restaurante
   /* public class cargos
    {
        public int id_cargos { get; set; }
        public BinaryData cargo { get; set; }

    }*/

    public class combos
    {
        [Key]
        public int id_combo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
        public int id_estado { get; set; }


    }

    public class categorias
    {
        [Key]
        public int id_categoria { get; set; }
        public string categoria { get; set; }

    }

    public class Cuenta
    {
        [Key]
        public int Id_cuenta { get; set; }
        public int Id_mesa { get; set; }
        public string Nombre { get; set; }
        public int Cantidad_Personas { get; set; }
        public string Estado_cuenta { get; set; }
        public DateTime Fecha_hora { get; set; }
    }


    public class detalle_fac
    {
        [Key]
        public int id_detallefac { get; set; }
        public int id_factura { get; set; }
        public int id_detallepedido { get; set; }
        public decimal precio { get; set; }
        public decimal total_plato { get; set; }
        public int cantidad { get; set; }

    }

    //Esta es parecida específica para los pedidos del restaurante
    public class Detalle_pedido
    {
        [Key]
        public int Id_DetalleCuenta { get; set; }
        public int Id_cuenta { get; set; }
        public int Id_plato { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string Tipo_Plato { get; set; }
        public decimal precio {  set; get; }
    }


    public class empleados
    {
        [Key]   
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
        public int id_cargo { get; set; }
        public int id_estado { get; set; }


    }

    public class encabezado_fac
    {
        [Key]
        public int id_factura { get; set; }
        public int id_pedido { get; set; }
        public int id_cliente { get; set; }
        public DateTime fecha_cobro { get; set; }
        public decimal total_cobrado { get; set; }
        public string metodo_pago { get; set; }

    }

    public class estados
    {
        [Key]
        public int id_estado { get; set; }
        public string nombre { get; set; }
        public string tipo_estado { get; set; }
    }

    public class items_combo
    {
        [Key]
        public int id_combo { get; set; }
        public int id_item_menu { get; set; }
    }

    public class items_menu
    {
        [Key]
        public int id_item_menu { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
        public int id_estado { get; set; }
        public int id_categoria { get; set; }

    }

    public class items_promo
    {
        [Key]
        public int id_promo { get; set; }
        public int id_item_menu { get; set; }

    }

    public class mesas
    {
        [Key]
        public int id_mesa { get; set; }
        public int cantidad_personas { get; set; }
        public int id_estado { get; set; }
        public string nombre_mesa { get; set; }

    }

    public class promociones
    {
        [Key]
        public int id_promo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha_inicio { get; set; }
        public decimal fecha_final { get; set; }
        public string imagen { get; set; }
        public int id_estado { get; set; }
        public string nombre { get; set; }

    }
}
