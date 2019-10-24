using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        //Annotations ASP.NET Core
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descrição:")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "No maxímo 100 caracteres")]
        public string  Descricao{ get; set; }

        [Display(Name = "Preço:")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double? Preco { get; set; }

        [Display(Name = "Quantidade:")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1,1000, ErrorMessage ="A quantidade deve estar entre 1 e 1000")]
        public int? Quantidade { get; set; }
        public DateTime CriadoEm { get; set; }

        public Produto()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
