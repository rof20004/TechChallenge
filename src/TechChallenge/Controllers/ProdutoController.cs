using Microsoft.AspNetCore.Mvc;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param nome="nome"></param>
        /// <param categoria="categoria"></param>
        /// <param valor="valor"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateProduto(string nome, int categoria, decimal valor)
        {
            try
            {
                await _produtoService.CreateProduto(nome, categoria, valor);

                return Ok($"Produto {nome} criado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca Produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _produtoService.GetProdutos();

                if (produtos.Count.Equals(0))
                {
                    return BadRequest("Não encontramos nenhum produto cadastrado.");
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca Produto
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            try
            {
                var produto = await _produtoService.GetProduto(id);

                if (produto is null)
                {
                    return BadRequest($"Não encontramos o cadastro do id {id}.");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta Produto
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtoService.RemoveProduto(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera Produto
        /// </summary>
        /// <returns></returns>
        [HttpPost("Alter")]
        public async Task<ActionResult> AlterProduto(int id, string nome, int categoria, decimal valor)
        {
            try
            {
                await _produtoService.AlterProduto(id, nome, categoria, valor);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }
    }
}
