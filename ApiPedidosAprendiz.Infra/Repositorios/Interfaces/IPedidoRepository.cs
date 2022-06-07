using ApiPedidosAprendiz.Infra.Models;

namespace ApiPedidosAprendiz.Repositorios.Interfaces
{
    public interface IPedidoRepository
    {
        // nome de todos os metodos esperados

        Task<List<Pedidos>> GetPedidosAsync();
        Task<Pedidos> PedidoByIdAsync(int id);
        Task<int> NovoPedidoAsync(Pedidos novoPedido);
        Task<int> UpdatePedidoAsync(Pedidos atualizarPedidos);
        Task<int> DeletarPedidoAsync(int id);

        Task<Pedidos> PedidosPorEntidadeAsync(int id);


    }
}
