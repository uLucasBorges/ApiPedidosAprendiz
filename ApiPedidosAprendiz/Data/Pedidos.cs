namespace ApiPedidosAprendiz.Data
{
    public class Pedidos
    {
        // nome das tabelas no banco
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
    }
}
