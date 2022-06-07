using ApiPedidosAprendiz.Infra.Data;
using ApiPedidosAprendiz.Infra.Models;
using ApiPedidosAprendiz.Infra.Repositorios.Interfaces;
using ApiPedidosAprendiz.Repositorios.Interfaces;
using Dapper;
using Refit;

namespace ApiPedidosAprendiz.Infra.Repositorios
{
    public class EntidadeRepository : IEntidadeRepository
    {
        public ICepService _cepService;
        private DbContext _db;

        public EntidadeRepository(DbContext dbContext ,ICepService cepService)
        {
            _db = dbContext;
            _cepService = cepService;
        }

      

   

        public async Task<List<Entidades>> GetEntidadesAsync()
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = "SELECT * FROM EntidadesAprendiz";
                    List<Entidades> pedidos = (await conn.QueryAsync<Entidades>(sql: query)).ToList();
                    if (pedidos.Count == 0)
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


        public async Task<Entidades> EntidadeByIdAsync(int Id)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string query = "select * from EntidadesAprendiz WHERE id in (@id)";
                    Entidades entidades = await conn.QueryFirstOrDefaultAsync<Entidades>(sql: query, param: new { Id });
                    return entidades;
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperadó");
            }


        }
        public async Task<int> NovaEntidadeAsync(Entidades entidades)
        {

            try
            {
                using (var conn = _db.Connection)
                {
                    var cepEntidade = _cepService.GetAddressAsync(entidades.Cep);
                   

                    string command = @"INSERT INTO EntidadesAprendiz(Nome,Endereco,Responsavel) values(@Nome,@ entidades.Logradouro,@Responsavel)";

                    var result = await conn.ExecuteAsync(sql: command, param: entidades);

                    return result;
                }
            }
            catch (Exception)
            {
                throw new Exception("NÂO FOI POSSIVEL INSERIR.");
            }

        }

        public async Task<int> UpdateEntidadeAsync(Entidades entidades)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"UPDATE EntidadesAprendiz SET nome = @Nome , Endereco = @Endereco, Responsavel = @Responsavel WHERE id = @Id";
                    var result = await conn.ExecuteAsync(sql: command, param: entidades);

                    return result;

                }
            }
            catch
            {
                throw new Exception("Erro , não foi possivel realizar a atualização.");
            }

        }

        public async Task<int> DeletarEntidadeAsync(int Id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"DELETE FROM EntidadesAprendiz WHERE id = @Id";
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

