using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcTrabalinho.Models
{
    public class ProdutoModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto:")]
        [Display(Name = "Produto:")]
        public String pproduto { get; set; }

        [Display(Name = "Marca:")]
        public String marca { get; set; }

        [Display(Name = "Descrição:")]
        public String descricao { get; set; }

        [Required(ErrorMessage = "Digite o preço do produto:")]
        [Display(Name = "Preço:")]
        public double price { get; set; }

        public virtual ICollection<PedidoModel> pedido { get; set; }
    }
}