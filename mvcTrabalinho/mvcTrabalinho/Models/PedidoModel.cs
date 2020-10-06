using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcTrabalinho.Models
{
    public class PedidoModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Display(Name = "Nome:")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [Display(Name = "CPF:")]
        public Int64 Cpf { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP:")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço:")]
        public String endereco { get; set; }

        public int? ProdutoID { get; set; }
        public ProdutoModel pproduto { get; set; }

    }
}