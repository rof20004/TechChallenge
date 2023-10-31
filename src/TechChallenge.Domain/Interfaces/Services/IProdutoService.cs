using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        public Task<List<Produto>> GetProdutos();
        public Task CreateProduto(string nome, int categoria, decimal valor);
        public Task AlterProduto(int id, string nome, int categoria, decimal valor);
        public Task<Produto> GetProduto(int id);
        public Task RemoveProduto(int id);
    }
}