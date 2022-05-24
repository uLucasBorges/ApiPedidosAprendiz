using ApiPedidosAprendiz.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPedidosAprendiz.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        //implementação dos metodos

        private DbContext _db;
        public PedidoRepository(DbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<Pedidos>> GetPedidos()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM PedidosAprendiz";
                List<Pedidos> pedidos = (await conn.QueryAsync<Pedidos>(sql: query)).ToList();
                return pedidos;
            }
        }

        public async Task<Pedidos> PedidoById(int Id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM PedidosAprendiz WHERE id = @Id";
                Pedidos pedidos = await conn.QueryFirstOrDefaultAsync<Pedidos>(sql: query, param: new { Id });
                return pedidos;
            }
        }

        public async Task<int> NovoPedido(Pedidos pedido)
        {
            using (var conn = _db.Connection)
            {
                string command = @"INSERT INTO PedidosAprendiz(id,nome,categoria,preco) values(@Id,@Nome,@Categoria,@Preco)";

                var result = await conn.ExecuteAsync(sql: command, param: pedido);
                return result;
            }
        }

        public async Task<int> UpdatePedido(Pedidos pedido)
        {
            using (var conn = _db.Connection)
            {
               string command =  @"UPDATE PedidosAprendiz SET nome = @Nome , categoria = @Categoria, preco = @Preco WHERE id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: pedido);
                return result;
            }
        }

        public async Task<int> DeletarPedido(int Id)
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM PedidosAprendiz WHERE id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: new { Id });
                return result;
            }
        }



    }
}
