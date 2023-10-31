using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Infra
{
    public interface IClienteRepository
    {
        public Task<Cliente> GetCliente(string cpf);
        public Task CreateCliente(Cliente cliente);
        public Task<bool> ExistCliente(string cpf);
    }
}