using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPedidosAprendiz.Infra.Models;
using ApiPedidosAprendiz.Infra.Repositorios.Interfaces;
using Refit;

namespace ApiPedidosAprendiz.Infra.Repositorios
{
    public class CepRepository : ICepService
    {
        public async Task<CepResponse> GetAddressAsync(string cep)
        {
            try
            {
                var cepClient = RestService.For<ICepService>("http://viacep.com.br");

                return await cepClient.GetAddressAsync(cep);


            }
            catch (Exception e)
            {
                throw new Exception($"Falha...{e.Message}");
            }
        }
    }
}
