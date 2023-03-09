using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_aylin.Entidades
{
    public class Cliente
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Se requiere el campo nombre")]
        [StringLength(maximumLength:20, ErrorMessage = "El nombre debe tener un maximo de 20 caracteres")]
        public string nombre { get; set; } = default!;
        //[NotMapped]
        [Required(ErrorMessage = "Se requiere el campo telefono")]
        //[Range(0, 1000, ErrorMessage = "tel no puede superar 100")]
        public int telefono { get; set; }
    }
}
