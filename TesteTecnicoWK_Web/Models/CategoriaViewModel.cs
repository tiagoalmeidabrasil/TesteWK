using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK_Web.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descripcion { get; set; }
        public String? Tipo { get; set; }
    }
}