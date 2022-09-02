using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TesteTecnicoWK_Web.Models
{
    public class ProdutosViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Tipo { get; set; }
        public int Estoque { get; set; }
        public int? CategoriaId { get; set; }
        public virtual CategoriaViewModel? Categoria { get; set; }


    }
}
