using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloGerente___DAW.Models
{
    public class detalle_de_pedido
    {
        [Key]
        public int id_detalle_pedido { get; set; }
        public int id_comida { get; set; }
        public int id_pedido { get; set; }
        public pedido pedido { get; set; }
        public comida comida { get; set; }
    }
}
