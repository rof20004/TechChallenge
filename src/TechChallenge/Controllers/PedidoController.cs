using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Controllers
{
    [ApiController]
    [Route("api/v1/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Cria Pedidos com indentificação do cliente.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreatePedidoCliente([FromBody] List<int> idProdutos, string idCliente)
        {
            try
            {
                if (!idProdutos.Count.Equals(0))
                {
                    var idPedido = await _pedidoService.CreatePedido(idCliente, idProdutos);
                    return Ok($"Pedido {idPedido} enviado para cozinha.");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Cria Pedidos Anonimamente.
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateWithoutCliente")]
        public async Task<ActionResult<int>> CreatePedidoAnonimo([FromBody] List<int> idProdutos)
        {
            try
            {
                if (!idProdutos.Count.Equals(0))
                {
                    var idPedido = await _pedidoService.CreatePedido("0", idProdutos);
                    return Ok($"Pedido {idPedido} enviado para cozinha.");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca Pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Pedido>>> GetPedidos()
        {
            try
            {
                var pedidos = await _pedidoService.GetPedidos();

                if (pedidos.Count.Equals(0))
                {
                    return BadRequest("Não encontramos nenhum pedido cadastrado.");
                }

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca Pedido
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedido(id);

                if (pedido is null)
                {
                    return BadRequest($"Não encontramos o pedido do id {id}.");
                }

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }
    }
}
