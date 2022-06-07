using ApiPedidosAprendiz.Infra.Data;
using ApiPedidosAprendiz.Infra.Models;
using ApiPedidosAprendiz.Repositorios.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiPedidosAprendiz.Infra.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        //implementação dos metodos

        private DbContext _db;
        public PedidoRepository(DbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Pedidos> PedidosPorEntidadeAsync(int Id)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string query = " SELECT * FROM PedidosAprendiz WHERE Entidade_id = @id";
                    Pedidos pedidos = await conn.QueryFirstOrDefaultAsync<Pedidos>(sql: query, param: new { Id });
                    return pedidos;
                }


            }
            catch (Exception e)
            {
                throw new Exception ($"Ocorreu um Erro ao Buscar Os Pedidos {e.Message}");
            }


        }



        public async Task<List<Pedidos>> GetPedidosAsync()
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = "SELECT * FROM PedidosAprendiz";
                    List<Pedidos> pedidos = (await conn.QueryAsync<Pedidos>(sql: query)).ToList();
                    if(pedidos.Count == 0)
                    {
                        pedidos = null;
                        return pedidos;
                    }
                    else
                    {
                        return pedidos;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception("Erro inesperado");
            }
        }


        public async Task<Pedidos> PedidoByIdAsync(int Id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
 
                        string query = "select * from PedidosAprendiz WHERE id in (@id)";
                        Pedidos pedidos = await conn.QueryFirstOrDefaultAsync<Pedidos>(sql: query, param: new { Id });
                        return pedidos;
                }
               
              
            } catch (Exception e)
            {
                throw new Exception("Erro inesperadó");
            }
                
            
        }
        public async Task<int> NovoPedidoAsync(Pedidos pedido)
        {

            try
            {
                using (var conn = _db.Connection)
                {
                    
                    string command = @"INSERT INTO PedidosAprendiz(nome,endereco,preco,entidade_id) values(@Nome,@Endereco,@Preco,@Entidade_id)";

                    var result = await conn.ExecuteAsync(sql: command, param: pedido);
                    return result;
                }
            }
            catch (Exception)
            {
                throw new Exception("NÂO FOI POSSIVEL INSERIR.");
            }
            
        }

        public async Task<int> UpdatePedidoAsync(Pedidos pedido)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"UPDATE PedidosAprendiz SET nome = @Nome , endereco = @Endereco, preco = @Preco , entidade_id = @Entidade_id WHERE id = @Id";
                    var result = await conn.ExecuteAsync(sql: command, param: pedido);
           
                     return result;
              
                }
            }
            catch
            {
                throw new Exception("Erro , não foi possivel realizar a atualização.");
            }
            
        }

        public async Task<int> DeletarPedidoAsync(int Id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"DELETE FROM PedidosAprendiz WHERE id = @Id";
                    var result = await conn.ExecuteAsync(sql: command, param: new { Id });
                    return result;
                }
            }
            catch (Exception)
            {
              
                throw new Exception("ERRO INESPERADO");
            }
            
        }

     


    }


}
