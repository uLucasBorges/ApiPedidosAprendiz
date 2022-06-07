using ApiPedidosAprendiz.Infra.Models;
using ApiPedidosAprendiz.Repositorios.Interfaces;
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
        public async Task<IActionResult> GetPedidosAsync()
        {
            
            var result = await _pedidoRepository.GetPedidosAsync();
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("DEVEM EXISTIR PELO MENOS UM PEDIDO PARA SER PROCESSADO. ");
            }
               
         
           
        }


        [HttpGet]
        [Route("PEDIDOSBYENTIDADE")]
        public async Task<IActionResult> PedidosPorEntidade(int id)
        {

            var result = await _pedidoRepository.PedidosPorEntidadeAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("DEVEM EXISTIR PELO MENOS UM PEDIDO PARA SER PROCESSADO. ");
            }

        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult>PedidoById(int id)
        {
                var resul = await _pedidoRepository.PedidoByIdAsync(id);
                if(resul != null)
                {
                    return Ok(resul);
                }
                return BadRequest("NÃO FOI POSSIVEL LOCALIZAR ESSE ID EM NOSSA BASE DA DADOS !");
            

           
  
        }

      

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Novopedido(Pedidos pedido)
        {

                var resul = await _pedidoRepository.NovoPedidoAsync(pedido);
            if (pedido.Id <= 0 || pedido.Nome.Length <= 0 || pedido.Preco <= 0) 
            {
                return BadRequest("Preencha corretamente");
            }
               return Ok(resul);

          

        }


        [HttpPut]
       [Route("rename")]
       public async Task<IActionResult> UpdatePedido(Pedidos pedido)
        {
            var resul = await _pedidoRepository.UpdatePedidoAsync(pedido);
            if (pedido.Id <= 0 ||pedido.Nome.Length <= 0 || pedido.Preco <= 0)
            {
                return BadRequest("Preencha corretamente");
            }
            return Ok(resul);


        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> DeletarPedidos(int id)
        {
           
            
                var resul = await _pedidoRepository.DeletarPedidoAsync(id);
            if(resul != 0)
            {
                return Ok("PEDIDO DELETADO ! !");
            }

            return BadRequest(404);
         
        }

    }

    }

