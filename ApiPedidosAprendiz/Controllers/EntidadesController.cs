using ApiPedidosAprendiz.Infra.Models;
using ApiPedidosAprendiz.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidosAprendiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {

            private readonly IEntidadeRepository _entidadeRepository;

            public EntidadesController(IEntidadeRepository entidadeRepository)
            {
                _entidadeRepository = entidadeRepository;
            }

        [HttpGet]
        [Route("ListEntities")]
        public async Task<IActionResult> GetEntidades()
        {

            var result = await _entidadeRepository.GetEntidades();
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
            public async Task<IActionResult> PedidoById(int id)
            {
                var resul = await _entidadeRepository.EntidadeById(id);
                if (resul != null)
                {
                    return Ok(resul);
                }
                return BadRequest("NÃO FOI POSSIVEL LOCALIZAR ESSE ID EM NOSSA BASE DA DADOS !");

            }




            [HttpPost]
            [Route("new")]
            public async Task<IActionResult> NovaEntidade(Entidades entidades)
            {

                var resul = await _entidadeRepository.NovaEntidade(entidades);
                if (entidades.Responsavel.Length <= 0 || entidades.Nome.Length <= 0 || entidades.Endereco.Length <= 0)
                {
                    return BadRequest("Preencha corretamente");
                }
                return Ok(resul);



            }


            [HttpPut]
            [Route("rename")]
            public async Task<IActionResult> UpdatePedido(Entidades entidades)
            {
                var resul = await _entidadeRepository.UpdateEntidade(entidades);
                if (entidades.Responsavel.Length <= 0 || entidades.Nome.Length <= 0 || entidades.Endereco.Length <= 0)
                {
                    return BadRequest("Preencha corretamente");
                }
                return Ok(resul);


            }

            [HttpDelete]
            [Route("remove")]
            public async Task<IActionResult> DeletarPedidos(int id)
            {


                var resul = await _entidadeRepository.DeletarEntidade(id);
                if (resul != 0)
                {
                    return Ok("PEDIDO DELETADO ! !");
                }

                return BadRequest(404);

            }
        }
    }

