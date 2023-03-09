using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_aylin.Entidades
{
    public class Producto
    {
        //[Required(ErrorMessage = "Se requiere el campo ID")]
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }
        public string modelo { get; set; } = default!;
        public int numSerial { get; set; }
    }
}
