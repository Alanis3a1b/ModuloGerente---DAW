using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModuloGerente___DAW.Models
{
    public class pedido
    {
        [Key]
        public int id_pedido { get; set; }
        public string estado { get; set; }
    }
}
