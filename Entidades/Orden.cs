using System.ComponentModel.DataAnnotations;

namespace webapp_aylin.Entidades
{
    public class Orden
    {
        [Required(ErrorMessage = "Se requiere el campo ID")]
        public int IdOrden { get; set; }
        [Required(ErrorMessage = "Se requiere el campo ID cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Se requiere el campo ID producto")]

        public int IdProducto { get; set; }
        public string Fecha { get; set; } = default!;
    }
}
