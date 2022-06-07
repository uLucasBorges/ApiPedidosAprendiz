using ApiPedidosAprendiz.Infra.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidosAprendiz.Controllers
{
    [ApiController]
    [Route("Cep")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cep;

        public CepController(ICepService cep)
        {
            _cep = cep;
        }

        [HttpGet]
        [Route("cep")]
        public async Task<IActionResult> Get(string cep)
        {
            var result = await _cep.GetAddressAsync(cep);
            return Ok(result);
        }


    }
}
