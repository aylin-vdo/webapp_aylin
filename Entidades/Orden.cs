using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_aylin.Entidades
{
    public class Orden
    {
        
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOrden { get; set; }
        [Required(ErrorMessage = "Se requiere el campo ID cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Se requiere el campo ID producto")]

        public int IdProducto { get; set; }
        public string Fecha { get; set; } = default!;
    }
}
