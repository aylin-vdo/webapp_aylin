using System.ComponentModel.DataAnnotations;

namespace webapp_aylin.Entidades
{
    public class Producto
    {
        [Required(ErrorMessage = "Se requiere el campo ID")]
        public int IdProducto { get; set; }
        public string modelo { get; set; } = default!;
        public int numSerial { get; set; }
    }
}
