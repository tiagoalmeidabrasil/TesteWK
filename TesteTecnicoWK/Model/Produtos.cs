using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteTecnicoWK.Model
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        public string? Tipo { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Estoque { get; set; }

        public int? CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categorias? Categorias { get; set; }


    }
}
