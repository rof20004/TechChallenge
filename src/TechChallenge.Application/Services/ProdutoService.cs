using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Application.Services;
public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task AlterProduto(int id, string nome, int categoria, decimal valor)
    {
        Produto produto = new Produto() { Id = id, Nome = nome, Categoria = categoria, Valor = valor };
        await _produtoRepository.EditProduto(produto);
    }

    public async Task CreateProduto(string nome, int categoria, decimal valor)
    {
        Produto produto = new Produto()
        {
            Nome = nome,
            Categoria = categoria,
            Valor = valor
        };

        await _produtoRepository.CreateProduto(produto);
    }

    public async Task<Produto> GetProduto(int id)
    {
       return await _produtoRepository.GetProduto(id);
    }

    public async Task<List<Produto>> GetProdutos()
    {
        return await _produtoRepository.GetProdutos();
    }

    public async Task RemoveProduto(int id)
    {
        await _produtoRepository.DeleteProduto(id);
    }
}
