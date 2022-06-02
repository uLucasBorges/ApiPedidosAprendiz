using ApiPedidosAprendiz.Models;

namespace ApiPedidosAprendiz.Repositorios.Interfaces
{
    public interface IEntidadeRepository
    {
        Task<List<Entidades>> GetEntidades();
        Task<Entidades> EntidadeById(int id);
        Task<int> NovaEntidade(Entidades novaEntidade);
        Task<int> UpdateEntidade(Entidades novaEntidade);
        Task<int> DeletarEntidade(int id);



    }
}
