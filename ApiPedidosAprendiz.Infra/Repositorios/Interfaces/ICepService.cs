using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPedidosAprendiz.Infra.Models;
using Refit;

namespace ApiPedidosAprendiz.Infra.Repositorios.Interfaces
{
    public interface ICepService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
