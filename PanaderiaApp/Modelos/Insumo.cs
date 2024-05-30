using System.ComponentModel.DataAnnotations;

namespace PanaderiaApp.Modelos
{
    public class Insumo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necesitas un nombre")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]

        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Necesitas una descripcion")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Necesitas un precio")]
        [Range(1, 200, ErrorMessage = "El precio debe seer mayor a 0")]
        public string? Precio { get; set; }

        // Propiedades de navegacion EF
        virtual public ICollection<Proveedor>? Proveedores { get; set;}
    }
}
