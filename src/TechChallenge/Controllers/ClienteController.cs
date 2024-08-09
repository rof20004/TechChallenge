using Microsoft.AspNetCore.Mvc;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Controllers
{
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        /// <summary>
        /// Retorna os dados do Cliente atráves do CPF
        /// </summary>
        /// <param cpf="cpf"></param>
        /// <returns></returns>
        [HttpGet("{cpf}")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<ActionResult<Cliente>> GetCliente(string cpf)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(cpf);

                if (cliente is null)
                {
                    return NotFound($"O CPF {cpf} ainda não é um cliente.");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Retorna os dados do Cliente atráves do CPF
        /// </summary>
        /// <param cpf="cpf"></param>
        /// <returns></returns>
        [HttpPost("{cpf}")]
        public async Task<ActionResult<int>> CreateCliente(string cpf, string email, string nome, string telefone, string endereco)
        {
            try
            {
                if (cpf is null)
                {
                    return BadRequest("CPF deve ser obrigatório");
                }

                var idCliente = await _clienteService.CreateCliente(cpf, email, nome, telefone, endereco);

                if (idCliente != 0)
                {
                    return Ok($"Bem Vindo {nome} você é o nosso cliente número {idCliente}.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }

            return BadRequest($"O CPF {cpf} já esta cadastrado.");
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult<int>> DeleteCliente(string cpf)
        {
            try
            {
                if (cpf is null)
                {
                    return BadRequest("CPF deve ser obrigatório para exclusão do usuario");
                }

                var cliente = await _clienteService.GetCliente(cpf);

                var idCliente = _clienteService.DeleteCliente(cliente);

                if (idCliente != null)
                {
                    return Ok($"{idCliente}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }

            return BadRequest($"Não foi possivel realizar a exclusão do seu usuario");
        }
    }
}
