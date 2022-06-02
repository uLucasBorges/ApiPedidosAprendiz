using ApiPedidosAprendiz.Infra.Models;

namespace ApiPedidosAprendiz.Repositorios.Interfaces
{
    public interface IPedidoRepository
    {
        // nome de todos os metodos esperados

        Task<List<Pedidos>> GetPedidos();
        Task<Pedidos> PedidoById(int id);
        Task<int> NovoPedido(Pedidos novoPedido);
        Task<int> UpdatePedido(Pedidos atualizarPedidos);
        Task<int> DeletarPedido(int id);

        Task<Pedidos> PedidosPorEntidade(int id);


    }
}
