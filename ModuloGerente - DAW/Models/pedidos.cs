using System.ComponentModel.DataAnnotations;

namespace ModuloGerente___DAW.Models
{
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
        public int id_usuario { get; set;}
    }

    public class usuarios
    {
        [Key]
        public int id_usuario { get; set; }

    
    }

}
