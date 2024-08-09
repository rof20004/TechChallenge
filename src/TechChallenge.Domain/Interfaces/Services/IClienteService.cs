using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        public Task<Cliente> GetCliente(string cpf);
        public Task<int> CreateCliente(string cpf, string email, string nome, string telefone, string endereco);

        public string DeleteCliente(Cliente cliente);
    }
}