using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloGerente___DAW.Models
{
    public class comida
    {
        [Key]
        public int id_comida { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
    }
}
