using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Infra
{
    public interface IProdutoRepository
    {
        public Task<Produto> GetProduto(int id);
        public Task DeleteProduto(int id);
        public Task EditProduto(Produto produto);
        public Task<List<Produto>> GetProdutos();
        public Task CreateProduto(Produto produto);
    }
}