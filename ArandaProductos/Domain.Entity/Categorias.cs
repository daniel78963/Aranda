using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }

    }
}
