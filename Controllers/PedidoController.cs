using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TechChallenge.Models.Pedido;
using TechChallenge.Models.Produto;

namespace TechChallenge.Controllers
{
    [ApiController]
    [Route("api/v1/pedido")]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<Produto>> GetAsync()
        {
            return null;
        }

        [HttpPost("cria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Produto> PostAsync([FromBody] Pedido produto)
        {
            return null;
        }

        [HttpPut("atualiza/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Produto> PutAsync([FromRoute] int id, [FromBody] Produto produto)
        {
            return null;
        }

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Produto> DeleteAsync([FromRoute] int id)
        {
            return null;
        }
    }
}
