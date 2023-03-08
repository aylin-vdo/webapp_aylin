using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_aylin.Entidades
{
    public class Cliente
    {
        [Required(ErrorMessage = "Se requiere el campo ID")]
        [Range(0,100, ErrorMessage = "Id no puede superar 100")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Se requiere el campo nombre")]
        [StringLength(maximumLength:20, ErrorMessage = "El nombre debe tener un maximo de 20 caracteres")]
        public string nombre { get; set; } = default!;
        //[NotMapped]
        public int telefono { get; set; }
    }
}
