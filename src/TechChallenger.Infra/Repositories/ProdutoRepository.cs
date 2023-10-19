using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Infra.Data;

namespace TechChallenge.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApiDbContext _context;

        public ProdutoRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduto(int id)
        {
            await _context.Produto.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync();
        }

        public async Task EditProduto(Produto produto)
        {
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
        }
        public async Task<Produto> GetProduto(int id)
        {
            return await _context.Produto.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produto.ToListAsync();
        }
    }
}