
using System.Data;
using System.Data.SqlClient;
namespace ApiPedidosAprendiz.Data
{

    // minha conexao com o banco 
    public class DbContext : IDisposable
    {
        public IDbConnection Connection { get; set; }

        public DbContext(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("Default"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();

    }
}
