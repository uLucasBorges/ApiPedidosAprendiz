using System.ComponentModel.DataAnnotations;

namespace ApiPedidosAprendiz.Models
{
    public class Pedidos
    {
        // nome das tabelas no banco

        [Required(ErrorMessage = "Digite um id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite um Nome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve ter de 2-50 caracteres.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe o Preço do lanche.")]
        [Range(1, 99, ErrorMessage = "O Preco deve estar entre 1-99")]
        public double Preco { get; set; }

        public int Entidade_id { get; set; }
    }
}
