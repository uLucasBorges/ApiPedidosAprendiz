using ApiPedidosAprendiz.Infra.Models;

namespace ApiPedidosAprendiz.Repositorios.Interfaces
{
    public interface IEntidadeRepository
    {
        Task<List<Entidades>> GetEntidadesAsync();
        Task<Entidades> EntidadeByIdAsync(int id);
        Task<int> NovaEntidadeAsync(Entidades novaEntidade);
        Task<int> UpdateEntidadeAsync(Entidades novaEntidade);
        Task<int> DeletarEntidadeAsync(int id);



    }
}
