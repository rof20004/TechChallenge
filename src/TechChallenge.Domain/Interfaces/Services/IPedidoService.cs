using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        public Task<List<Pedido>> GetPedidos();

        public Task<Pedido> GetPedido(int idPedido);

        public Task<int> CreatePedido(string idCliente, List<int> idProdutos);

        public void PutStatusPedidos(Pedido entidade);
    }
}