using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Model
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public String? Tipo { get; set; }

        public virtual ICollection<Produtos>? Produtos { get; set; }


    }
}
