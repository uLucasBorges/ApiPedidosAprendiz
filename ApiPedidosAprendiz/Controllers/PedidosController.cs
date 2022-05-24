using ApiPedidosAprendiz.Data;
using ApiPedidosAprendiz.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidosAprendiz.Controllers
{

    // minhas rotas
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedido)
        {
            _pedidoRepository = pedido;
        }

        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> GetPedidos()
        {

            var result = await _pedidoRepository.GetPedidos();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest(error: 404);
           
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult>PedidoById(int id)
        {
            var resul = await _pedidoRepository.PedidoById(id);
            return Ok(resul);
        }


        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Novopedido(Pedidos pedido)
        {
            var resul = await _pedidoRepository.NovoPedido(pedido);
            
                return Ok(resul);
           
        }


        [HttpPut]
       [Route("rename")]
       public async Task<IActionResult> UpdatePedido(Pedidos pedido)
        {
            var resul = await _pedidoRepository.UpdatePedido(pedido);
            return Ok(resul);
           
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> DeletarPedidos(int id)
        {
            var resul = await _pedidoRepository.DeletarPedido(id);
            return Ok(resul);

        }

    }

    }

