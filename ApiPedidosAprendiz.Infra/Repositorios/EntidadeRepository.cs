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
                    var cepClient = RestService.For<ICepService>("http://viacep.com.br");
                    var resultcep = await cepClient.GetAddressAsync(entidades.Cep);


                    entidades.Bairro = resultcep.Bairro;
                    entidades.Complemento = resultcep.Complemento;
                    entidades.Localidade = resultcep.Localidade;
                    entidades.Logradouro = resultcep.Logradouro;
                    entidades.Uf = resultcep.Uf;
                    

                    string command = @"insert into EntidadesAprendiz(Nome,Responsavel,Cep,Logradouro,Bairro,Complemento,Localidade, Uf) values (@Nome,@Responsavel,@Cep,@Logradouro,@Bairro,@Complemento,@Localidade, @Uf)";

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

