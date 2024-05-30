using System.ComponentModel.DataAnnotations;

namespace PanaderiaApp.Modelos
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necesitas un nombre")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]

        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Necesitas una direccion")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]

        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Necesitas un Telefono")]
        [StringLength(10, ErrorMessage = "El numero debe ser de 10 caracteres")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Necesitas un Correo")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string? Correo { get; set; }


        virtual public ICollection<Insumo>? Insumos { get; set; }
    }
}

