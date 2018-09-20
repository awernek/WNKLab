using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WNKLab.Application.ModelView
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o código")]
        [MaxLength(4, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo {0} caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha o valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?")]
        public bool Disponivel { get; set; }

        //[DisplayName("Categoria")]
        //public int CategoriaId { get; set; }
        //public CategoriaViewModel CategoriaViewModel { get; set; }
    }
}
