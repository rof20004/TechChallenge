using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Infra.Data;

namespace TechChallenge.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApiDbContext _context;

        public ClienteRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistCliente(string cpf)
        {
            return await _context.Cliente.AnyAsync(x => x.CPF.Equals(cpf));
        }

        public async Task<Cliente> GetCliente(string cpf)
        {
            return await _context.Cliente.Where(x => x.CPF.Equals(cpf)).FirstOrDefaultAsync();
        }
    }
}